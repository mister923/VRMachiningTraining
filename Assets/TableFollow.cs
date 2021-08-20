using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject tableMovement;
    public Vector3 offset;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = tableMovement.transform.position+ offset;
    }
}
