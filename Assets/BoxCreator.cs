
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.InteropServices;

public class BoxCreator : MonoBehaviour
{


    //public GameObject cornerPrefab;
    public Color enterColor;
    public Color defaultColor = Color.red;
    //public GameObject box;
    public enum InstPoints { all, single };

    //


    public Vector3 correctLocation;


    void Start()
    {
        //VertexPoints(box.GetComponent<MeshFilter>(), InstPoints.all, cornerPrefab);     
    }

    public void VertexPoints(MeshFilter meshFilter, InstPoints instPoint, GameObject prefab, Quaternion orient, int cornerIndex = 0)
    {

        Vector3[] allVertices = meshFilter.mesh.vertices;
        Vector3[] uniqueVertices = allVertices.Distinct().ToArray();
        //Vector3[] uVertices = allVertices.Distinct().ToArray();        
        Vector3 boundPoint1 = meshFilter.mesh.bounds.min;
        Vector3 boundPoint2 = meshFilter.mesh.bounds.max;
        Vector3 boundPoint3 = new Vector3(boundPoint1.x, boundPoint1.y, boundPoint2.z);
        Vector3 boundPoint4 = new Vector3(boundPoint1.x, boundPoint2.y, boundPoint1.z);
        Vector3 boundPoint5 = new Vector3(boundPoint2.x, boundPoint1.y, boundPoint1.z);
        Vector3 boundPoint6 = new Vector3(boundPoint1.x, boundPoint2.y, boundPoint2.z);
        Vector3 boundPoint7 = new Vector3(boundPoint2.x, boundPoint1.y, boundPoint2.z);
        Vector3 boundPoint8 = new Vector3(boundPoint2.x, boundPoint2.y, boundPoint1.z);
        Vector3[] uVertices = new Vector3[] { boundPoint1, boundPoint2, boundPoint3, boundPoint4, boundPoint5, boundPoint6, boundPoint7, boundPoint8 };




        if (instPoint == InstPoints.all)
        {
            int i = 0;
            foreach (Vector3 vertex in uVertices)
            {
                Debug.Log("completed");
                GameObject corner = Instantiate(prefab, meshFilter.gameObject.transform);
                corner.transform.localPosition = vertex;
                corner.name = i.ToString();
                i += 1;
            }
        }
        else
        {
            if (uniqueVertices.Length <= 14)
            {

                Debug.Log(uVertices.Length);
                GameObject corner = Instantiate(prefab, Vector3.zero, Quaternion.identity, meshFilter.gameObject.transform);
                //GameObject corner = Instantiate(prefab);
                //corner.transform.SetParent(meshFilter.gameObject.transform);                
                corner.transform.localRotation = orient;
                corner.transform.localPosition = uVertices[cornerIndex];
                corner.name = "Corner" + meshFilter.name;
                correctLocation = uVertices[cornerIndex];
                Debug.Log("completed-2");

            }
            else
            {
                GameObject corner = Instantiate(prefab, Vector3.zero, Quaternion.identity, meshFilter.gameObject.transform);
                //GameObject corner = Instantiate(prefab);
                //corner.transform.SetParent(meshFilter.gameObject.transform);                
                corner.transform.localRotation = orient;
                corner.transform.localPosition = Vector3.zero;
                corner.name = "Corner" + meshFilter.name;
                correctLocation = meshFilter.gameObject.transform.position;

            }

        }
    }

    public void SelectChangeColor()
    {
        if (gameObject.GetComponent<MeshRenderer>().material.color != Color.green)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public void EnterChangeColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = enterColor;

    }

    public void ExitChangeColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = defaultColor;

    }

    private void VertexColorChanger()
    {


    }

    // Update is called once per frame



    void Update()
    {

    }
}
