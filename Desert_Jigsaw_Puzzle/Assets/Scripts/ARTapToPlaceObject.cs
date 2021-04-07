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
    public GameObject instructionsButton;
    private ARRaycastManager arRaycastManager;

    private Vector2 touchPosition;


    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
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
       
        if (!TryToTouch(out Vector2 touchPosition))
            return;

        if(arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if(spawnedObject == null)
            {
                spawnedObject = Instantiate(camel, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
        }
    }
    public void DisableInstructions()
    {
       instructions.SetActive(false);
       instructionsButton.SetActive(true);
    }
    public void EnableInstructions()
    {
        instructions.SetActive(true);
        instructionsButton.SetActive(false);
    }
}
