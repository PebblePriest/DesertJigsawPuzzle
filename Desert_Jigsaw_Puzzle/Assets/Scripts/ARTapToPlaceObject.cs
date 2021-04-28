using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{ 
    public GameObject instructions;
    public GameObject hud;
    [SerializeField]
    private GameObject selectedPrefab;
    
    public Button dismissButton;

    [SerializeField]
    private Button lockButton;

    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private float defaultRotation = 0;

    private GameObject spawnedObject;

    private Vector2 touchPosition = default;

    private ARRaycastManager arRaycastManager;

    private bool isLocked = false;

    private bool onTouchHold = false;

    private ARPlaneManager arPlaneM;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject ReadingPanel1;

    public GameObject IndexPanel;

    bool BiomeVocab = false;

    public GameObject BiomePanel;

    public bool panel1Enabled = false;

    public Animation anim;
    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneM = GetComponent<ARPlaneManager>();

        if (lockButton != null)
        {
            lockButton.onClick.AddListener(Lock);
        }
        anim = selectedPrefab.GetComponent<Animation>();
    }
    private void Lock()
    {
        isLocked = !isLocked;
        lockButton.GetComponentInChildren<Text>().text = isLocked ? "Locked" : "Unlocked";
        if (spawnedObject != null)
        {
            spawnedObject.GetComponent<PlacementObject>()
                .SetOverlayText(isLocked ? "AR Object Locked" : "AR Object Unlocked");
        }
    }

    void Update()
    {
        if(panel1Enabled == true)
        {
            anim.Play("CamelMove");
            Debug.Log("AnimationPlaying");

        }
       

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    PlacementObject placementObject = hitObject.transform.GetComponent<PlacementObject>();
                    if (placementObject != null)
                    {
                        onTouchHold = isLocked ? false : true;
                        placementObject.SetOverlayText(isLocked ? "AR Object Locked" : "AR Object Unlocked");
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
            }
        }

        if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                if (defaultRotation > 0)
                {
                    spawnedObject = Instantiate(selectedPrefab, hitPose.position, Quaternion.identity);
                    spawnedObject.transform.Rotate(Vector3.up, defaultRotation);
                }
                else
                {
                    spawnedObject = Instantiate(selectedPrefab, hitPose.position, hitPose.rotation);
                }
            }
            else
            {
                if (onTouchHold)
                {
                    spawnedObject.transform.position = hitPose.position;
                    if (defaultRotation == 0)
                    {
                        spawnedObject.transform.rotation = hitPose.rotation;
                    }
                }
                
            }
        }

    }
    public void DisableInstructions()
    {
       instructions.SetActive(false);
      
        hud.SetActive(true);
    }
    public void EnableInstructions()
    {
        instructions.SetActive(true);
        
        hud.SetActive(false);
    }
    public void TogglePlaneDetection()
    {
       
            
            arPlaneM.enabled = !arPlaneM.enabled;

            foreach(ARPlane plane in arPlaneM.trackables)
            {
                plane.gameObject.SetActive(arPlaneM.enabled);
            }
            //planeDetection.GetComponentInChildren<Text>.text = arPlaneM.enabled ? "Disable Plane Detection" : "Enable Plane Detection";
        
     
    }
    
    public void StartLesson()
    {
        ReadingPanel1.SetActive(true);
        hud.SetActive(false);
        BiomeVocab = true;
        panel1Enabled = true;
    }
    public void Index()
    {
        IndexPanel.SetActive(true);
        
       
    }
    public void Biome()
    {
     

            BiomePanel.SetActive(true);
        
    }
    public void Return()
    {
        BiomePanel.SetActive(false);
    }
   
    public void IndexOff()
    {
        IndexPanel.SetActive(false);
    }
}
