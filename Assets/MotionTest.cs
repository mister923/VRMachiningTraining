using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject waypoints;
    public GameObject moving;
    public float speed;
    public Transform[] positions;
    private int i;
    private Transform activeDest;
    private int pause;
    private float step;

    void Start()
    {

        positions = waypoints.GetComponentsInChildren<Transform>();
        i = 0;
        activeDest = positions[i];
        pause = 1;
    }
    
    IEnumerator pauseControl(int i)
    {
        yield return new WaitForSeconds(i);
    }

    IEnumerator Rotator()
    {
        moving.transform.rotation = Quaternion.RotateTowards(moving.transform.rotation, activeDest.rotation, step*5);
        yield return null;
    }

    IEnumerator Move()
    {
        moving.transform.position = Vector3.MoveTowards(moving.transform.position, activeDest.position, step);
        yield return null;
    }

    void Update()
    {
        activeDest = positions[i];
        step = Time.deltaTime * speed*pause;
        StartCoroutine("Rotator");
        StartCoroutine("Move");



        
        if(moving.transform.position==activeDest.position && moving.transform.rotation == activeDest.rotation)
        {
            if (i < positions.Length-1)
            {
                i += 1;
            }
            else
            {
                pause = 0;
                pauseControl(5);
                i = 0;
                pause = 1;
            }
        }
        

    }

}
        
      
        
        
    

