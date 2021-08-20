using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ParentingController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset cpInput;
    private string[] childParent;
    public TextManager textManager;

    void Start()
    {
        ReadFile();

    }

    public void ReadFile()
    {
        childParent = cpInput.text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

    }

    public void childParentIterator()
    {
        string[] cp = childParent[textManager.pageIndex-textManager.offs].Split(',');
        Debug.Log(cp);
        
        if(string.IsNullOrEmpty(cp[0]) && string.IsNullOrEmpty(cp[1]))
        {
            Debug.Log("parent nothing");
        }
        else
        {
            Debug.Log("string :" + cp[0]);
            Debug.Log("string :" + cp[1]);
            GameObject parent = GameObject.Find(cp[0]);
            GameObject child = GameObject.Find(cp[1]);
            child.transform.parent = parent.transform;
            child.transform.localPosition = Vector3.zero;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
