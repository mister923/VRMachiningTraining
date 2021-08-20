using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 3;
    float distancedTravelled;


  

    // Update is called once per frame
    void Update()
    {
        distancedTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distancedTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distancedTravelled);

    }
}
