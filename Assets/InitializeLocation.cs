using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLocation : MonoBehaviour
{
    public GameObject tool;// Start is called before the first frame update
    void Start()
    {
        transform.position = tool.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
