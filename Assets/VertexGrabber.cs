using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexGrabber : MonoBehaviour
{
    // Start is called before the first frame update
    Mesh mesh;
    Vector3[] vertices;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        foreach(Vector3 vertex in vertices)
        {
            Debug.Log(vertex);
        }
        mesh.vertices = vertices;
        //Debug.Log(vertices);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
}
/*
            (0.5, -0.5, 0.5)
            (-0.5, -0.5, 0.5)
            (0.5, 0.5, 0.5)
            (-0.5, 0.5, 0.5)
            (0.5, 0.5, -0.5)
            (-0.5, 0.5, -0.5)
            (0.5, -0.5, -0.5)
            (-0.5, -0.5, -0.5)
            (0.5, 0.5, 0.5)
            (-0.5, 0.5, 0.5)
            (0.5, 0.5, -0.5)
            (-0.5, 0.5, -0.5)
            (0.5, -0.5, -0.5)
            (0.5, -0.5, 0.5)
            (-0.5, -0.5, 0.5)
            (-0.5, -0.5, -0.5)
            (-0.5, -0.5, 0.5)
            (-0.5, 0.5, 0.5)
            (-0.5, 0.5, -0.5)
            (-0.5, -0.5, -0.5)
            (0.5, -0.5, -0.5)
            (0.5, 0.5, -0.5)
            (0.5, 0.5, 0.5)
            (0.5, -0.5, 0.5)

*/