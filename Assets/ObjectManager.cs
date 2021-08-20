using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform [] objects;
    private Vector3[] savedPosition;
    private Quaternion[] savedRotation;
    void Start()
    {
        List<Vector3> savedPos = new List<Vector3>();
        List<Quaternion> savedRot = new List<Quaternion>();
        foreach (Transform t in objects)
        {
            savedPos.Add(t.position);
            savedRot.Add(t.rotation);            

        }
        savedPosition = savedPos.ToArray();
        savedRotation = savedRot.ToArray();
    }

    public void ResetTable()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].position = savedPosition[i];
            objects[i].rotation = savedRotation[i];
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
