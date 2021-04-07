using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{ 

    public GameObject camel;

    
    private GameObject spawnedObject;
    public GameObject instructions;
  
    private ARRaycastManager arRaycastManager;
    public GameObject hud;
    private Vector2 touchPosition;
  

    private ARPlaneManager arPlaneM;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    [SerializeField]
    private Button lockButton;
    private bool isLocked = false;
    [SerializeField]
    private Camera arCamera;
    [SerializeField]
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
    bool TryToTouch(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(index:0).position;
            return true;
        }
        else
        {
           
            touchPosition = default;
            return false;
        }

      
    }

    void Update()
    {
        PlaceandDragObject();
        //if (!TryToTouch(out Vector2 touchPosition))
        //    return;

        //if(arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        //{
        //    var hitPose = hits[0].pose;

        //    if(spawnedObject == null)
        //    {
        //        spawnedObject = Instantiate(camel, hitPose.position, hitPose.rotation);
        //    }
        //    else
        //    {
        //        spawnedObject.transform.position = hitPose.position;
        //    }
        //}
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
    public void PlaceandDragObject()
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
                    spawnedObject = Instantiate(camel, hitPose.position, Quaternion.identity);
                    spawnedObject.transform.Rotate(Vector3.up, defaultRotation);
                }
                else
                {
                    spawnedObject = Instantiate(camel, hitPose.position, hitPose.rotation);
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
}
