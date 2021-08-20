using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{ 
    
    
    public GameObject trackingObject;    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = trackingObject.transform.position;
        transform.rotation = trackingObject.transform.rotation;
    }
}
