using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;


public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject testlocation;
    public TextAsset textfile;
    

    void Start()
    {
        
        string[] textdeets = textfile.text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        testlocation = GameObject.Find(textdeets[3]);
        //Debug.Log(testlocation.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = testlocation.transform.position;
    }
}
