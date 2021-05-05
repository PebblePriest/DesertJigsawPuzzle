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
    public GameObject ReadingPanel2;
    public GameObject BiomePanel;
    public GameObject HumpPanel;
    public GameObject IndexPanel;
    public GameObject ErrorPanel;
    public GameObject AdaptPanel;
    public GameObject HabitatPanel;
    public GameObject SettingPanel;
    public GameObject InteractivePanel1;
    public GameObject QuestionPanel1;
    public GameObject QuestionPanel2;

    //Booleans used to control if a vocab word shows up in the index
    public bool BiomeVocab = false;
    public bool humpVocab = false;
    public bool adaptVocab = false;
    public bool habitatVocab = false;
    public bool readinglesson = false;
    public bool interaction = false;
   
    private Animation anim;

    public GameObject NextBttn;
    public GameObject NextBttn2;
    public GameObject intNextBtn;

    public AudioCode other;

    public float waittime = 30f;
    public float humpTime = 30f;
    public ButtonCode buttons;
    public Slider slider;
    
    private void Awake()
    {
       
            arRaycastManager = GetComponent<ARRaycastManager>();
            arPlaneM = GetComponent<ARPlaneManager>();
            

            if (lockButton != null)
            {
                lockButton.onClick.AddListener(Lock);
            }
            //anim = selectedPrefab.GetComponent<Animation>();
         
    }
    private void Start()
    {
        
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

        if(interaction == true)
        {
            anim["CamelBending"].normalizedTime = slider.value;
        }
        if(slider.value == 1)
        {
            IntBtn();
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
        Debug.Log(BiomeVocab);
        if(BiomeVocab == true)
        {
            if( readinglesson == true)
            {

                Debug.Log(waittime);
                waittime -= 1 * Time.deltaTime;
                if (waittime <= 0)
                {
                    waittime = 0;
                    NextBttn.SetActive(true);


                }

            }         
            
        }
        if (humpVocab == true)
        {
            if(readinglesson == true)
            {
                 Debug.Log(waittime);
                 humpTime -= 1 * Time.deltaTime;
                 if (humpTime <= 0)
                 {
                     humpTime = 0;
                     NextBttn2.SetActive(true);
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
        anim = spawnedObject.GetComponent<Animation>();
        anim.Play("CamelMoving");
        ReadingPanel1.SetActive(true);
        hud.SetActive(false);
        BiomeVocab = true;
        readinglesson = true;
        
        

    }
    public void Index()
    {
        IndexPanel.SetActive(true);
        other.StopAudio();
        readinglesson = false;
        
       
    }

    public void Return()
    {
        BiomePanel.SetActive(false);
        HumpPanel.SetActive(false);
        ErrorPanel.SetActive(false);
        HabitatPanel.SetActive(false);
        AdaptPanel.SetActive(false);
    }
    public void Setting()
    {
        SettingPanel.SetActive(true);

    }
    public void SettingOff()
    {
        SettingPanel.SetActive(false);
    }
   
    public void IndexOff()
    {
        IndexPanel.SetActive(false);
        readinglesson = true;
    }
    public void Question1()
    {
        QuestionPanel1.SetActive(true);
        ReadingPanel1.SetActive(false);
    }
    public void Question2()
    {
        QuestionPanel2.SetActive(true);
        ReadingPanel2.SetActive(false);
    }
  

    public void NextButton()
    {
        anim = spawnedObject.GetComponent<Animation>();
        anim.Play("CamelMoving2");
        ReadingPanel1.SetActive(false);
        QuestionPanel1.SetActive(false);
        ReadingPanel2.SetActive(true);
        humpVocab = true;
        readinglesson = true;
        

    }
    public void Interactive1()
    {
        QuestionPanel2.SetActive(false);
        ReadingPanel2.SetActive(false);
        InteractivePanel1.SetActive(true);
        interaction = true;
        anim.Play("CamelBending");
        anim["CamelBending"].speed = 0;
    }
    public void IntBtn()
    {
        intNextBtn.SetActive(true);
    }
   
   
    

    //Code used to activate vocab panels and error codes, all same code with different variables
    public void ErrorOff()
    {
        ErrorPanel.SetActive(false);
    }
    public void Biome()
    {
     if(BiomeVocab == true)
        {
            BiomePanel.SetActive(true);

        }
        else
        {
            ErrorPanel.SetActive(true);
        }

       
        
    }
    public void Hump()
    {
        if (humpVocab == true)
        {
            HumpPanel.SetActive(true);

        }
        else
        {
            ErrorPanel.SetActive(true);
        }



    }
    public void Habitat()
    {
        if (habitatVocab == true)
        {
            HabitatPanel.SetActive(true);

        }
        else
        {
            ErrorPanel.SetActive(true);
        }



    }
    public void Adapt()
    {
        if (adaptVocab == true)
        {
            AdaptPanel.SetActive(true);

        }
        else
        {
            ErrorPanel.SetActive(true);
        }



    }


}
