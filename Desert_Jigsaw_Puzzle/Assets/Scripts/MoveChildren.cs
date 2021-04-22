using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChildren : MonoBehaviour
{
    public GameObject fullTerrain;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = fullTerrain.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
