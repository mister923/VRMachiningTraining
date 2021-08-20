using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
public class LinearMotion : MonoBehaviour
{

    public GameObject movingObject;
    public float speed = 3;
    float distance;
    private List<Transform> waypointList = new List<Transform>();
    public Transform defaultWaypoint;
    private int waypointQty;
    public int waypointIndex;
    private int pause;
    private float step;
    public void Start()
    {
        waypointSetup(defaultWaypoint);        
        FreshStart();
    }

    public void TogglePause()
    {
        if (pause ==0) {pause =1;}
        else { pause = 0;}
    }

    public void FreshStart()
    {
        movingObject.transform.position = waypointList[0].position;
        movingObject.transform.rotation = waypointList[0].rotation;
        pause =0;
    }
    private void waypointSetup(Transform waypointParent)
    {
        waypointList.Clear();
        foreach(Transform tran in waypointParent)
        {
            //Debug.Log(tran.position.x);
            waypointList.Add(tran);
        }
        waypointQty = waypointList.Count;
        waypointIndex = 0;
    }

  
    public void WaypointFollow(Transform waypointParent)
    {

        waypointSetup(waypointParent);
        FreshStart();
        waypointIndex = 0;
        TogglePause();
       
    }

    public void setMovingObject(GameObject mover)
    {
        movingObject = mover;
        //movingObject.GetComponent<Rigidbody>
    }

    IEnumerator Move()
    {
        
        movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, waypointList[waypointIndex].position, step);
        yield return null;
    }

    IEnumerator Rotate()
    {
        movingObject.transform.rotation = Quaternion.RotateTowards(movingObject.transform.rotation, waypointList[waypointIndex].rotation, step*20);
        yield return null;
    }

    void Update()
    {
        step = pause * Time.deltaTime * speed;
        if (waypointList.Count <= 0)
        {
            //Debug.Log("List is empty");
            //Debug.Log("List is empty");
        }
        else
        {
            StartCoroutine("Move");
            StartCoroutine("Rotate");                  
            if (movingObject.transform.position == waypointList[waypointIndex].position && movingObject.transform.rotation == waypointList[waypointIndex].rotation)
            {
                if (waypointIndex+1< waypointQty)
                    waypointIndex += 1;
                if (waypointIndex == waypointQty)
                {
                    //waypointIndex = 0;
                    TogglePause();
                    //waypointList.Clear();

                }
        
            }

        }
        
    }
}
