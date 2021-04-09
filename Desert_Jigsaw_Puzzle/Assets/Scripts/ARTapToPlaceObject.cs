using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{ 

    public GameObject desertScene;
    public GameObject selectionMenu;
    
    private GameObject spawnedObject;
    public GameObject instructions;
  
    private ARRaycastManager arRaycastManager;
    public GameObject hud;
    private Vector2 touchPosition;
    public Text debugText;

    private ARPlaneManager arPlaneM;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    [SerializeField]
    private Button lockButton;
    private bool isLocked = false;
    [SerializeField]
    private Camera arCamera;
   
    private float defaultRotation = 0;
    private bool onTouchHold = false;
    
    private void Awake()
    {
        arPlaneM = GetComponent<ARPlaneManager>();
        arRaycastManager = GetComponent<ARRaycastManager>();
        if (lockButton != null)
        {
            lockButton.onClick.AddListener(Lock);
        }
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
                    spawnedObject = Instantiate(desertScene, hitPose.position, Quaternion.identity);
                    spawnedObject.transform.Rotate(Vector3.up, defaultRotation);
                }
                else
                {
                    spawnedObject = Instantiate(desertScene, hitPose.position, hitPose.rotation);
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
    

}
