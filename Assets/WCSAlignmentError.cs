using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCSAlignmentError : MonoBehaviour
{
    public GameObject correctPlacement;
    public GameObject currentWCSPlacement;
    [SerializeField]
    private GameObject indicatorObject;

    //Error Sensitivity
    [SerializeField]
    private float closeRange;
    [SerializeField]
    private float mediumRange;
    [SerializeField]
    private float longRange;   

    // Start is called before the first frame update
    void Start()
    {
        DetectPlacement();
        ErrorXYZChecker(DetectPlacement()[0], DetectPlacement()[1], DetectPlacement()[2]);
    }
    public float[] DetectPlacement()
    {
        float errorX = correctPlacement.transform.position.x - correctPlacement.transform.position.x;
        float errorY = correctPlacement.transform.position.y - correctPlacement.transform.position.y;
        float errorZ = correctPlacement.transform.position.z - correctPlacement.transform.position.z;
        float[] errorVals = new float[] { errorX, errorY, errorZ};

        return errorVals;
    }

    private void ErrorXYZChecker(float eX, float eY, float eZ)
    {
        StartCoroutine(ErrorMagnitudeIndicator(eX));
        StartCoroutine(ErrorMagnitudeIndicator(eY));
        StartCoroutine(ErrorMagnitudeIndicator(eY));
    }

    IEnumerator ErrorMagnitudeIndicator(float error)
    {
        if (error > longRange)
        {
            indicatorObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            if(error>mediumRange && error < longRange)
            {
                indicatorObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else
            {
                if( error>closeRange && error < mediumRange)
                {
                    indicatorObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                }
                else
                {
                    indicatorObject.GetComponent<MeshRenderer>().material.color = Color.green;
                }
            }
        }       
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        ErrorXYZChecker(DetectPlacement()[0], DetectPlacement()[1], DetectPlacement()[2]);
    }
}
