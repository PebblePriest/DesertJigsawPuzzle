﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlacementObject))]
public class PlacementRoation : MonoBehaviour
{
    private PlacementObject placementObject;
    [SerializeField]
    private Vector3 rotationSpeed =  Vector3.zero;
     void Awake()
    {
        placementObject = GetComponent<PlacementObject>();
    }
     void Update()
    {
      
            transform.Rotate(rotationSpeed * Time.deltaTime, Space.World);
        
    }
}
