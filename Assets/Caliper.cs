using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Globalization;
using System.Linq;

public class Caliper : MonoBehaviour
{
    // Start is called before the first frame update\
    [SerializeField] private GameObject moving;
    [SerializeField] private GameObject staticObject;
    [SerializeField] private TextMeshPro measure;
    void Start()
    {
        
    }
    
    Transform[] ColliderToTransform(Collider[] colliderz)
    {
        Transform[] colliderlocations= new Transform[] { };
        foreach(Collider cl in colliderz)
        {
            Transform candidate = cl.gameObject.transform;
            colliderlocations = colliderlocations.Concat(new Transform[] { candidate }).ToArray();
        }

        return colliderlocations;
    }

    Transform GetClosestObject(Transform[] objects)
    {
        Transform closestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in objects)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestTarget = potentialTarget;
            }
        }

        return closestTarget;
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 size=GetClosestObject(ColliderToTransform(Physics.OverlapSphere(new Vector3(0,0,0), .1f))).gameObject.GetComponent<Renderer>().bounds.size;
       
        var measurement = Vector3.Distance(staticObject.transform.position, moving.transform.position);
        if (measurement<0)
        {
            moving.transform.position = staticObject.transform.position;
        }
        measure.text = measurement.ToString("0.0000") + "X: " +size.x.ToString() + "Y: " + size.y.ToString() + "Z: " + size.z.ToString() + GetClosestObject(ColliderToTransform(Physics.OverlapSphere(new Vector3(0, 0, 0), .1f))).gameObject.name;
        moving.transform.position = new Vector3(staticObject.transform.position.x, staticObject.transform.position.y + size.x, staticObject.transform.position.z);
        moving.transform.rotation = staticObject.transform.rotation;
    }
}
