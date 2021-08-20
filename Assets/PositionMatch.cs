using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMatch : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform WorkCoordinteSystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = WorkCoordinteSystem.position;
    }
}
