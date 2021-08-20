using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWCS : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject WCS;
    [SerializeField] private GameObject SelectPlane;
    [SerializeField] private GameObject Box;
    [SerializeField] private GameObject TopPlane;

    float stockBottom;

    void Start()
    {
       
       // TopPlane.transform.localPosition = new Vector3(TopPlane.transform.position.x,  +Box.GetComponent<Renderer>().bounds.size.y, TopPlane.transform.position.z);
       // SelectPlane.transform.localPosition = new Vector3(SelectPlane.transform.position.x, (- Box.GetComponent<Renderer>().bounds.size.y), SelectPlane.transform.position.z);
    }

    void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 cornerpos = new Vector3(Box.GetComponent<Renderer>().bounds.center.x- Box.GetComponent<Renderer>().bounds.extents.x, Box.GetComponent<Renderer>().bounds.center.y - Box.GetComponent<Renderer>().bounds.extents.y, Box.GetComponent<Renderer>().bounds.center.z - Box.GetComponent<Renderer>().bounds.extents.z);
        WCS.transform.position = cornerpos;

        
    }
}
