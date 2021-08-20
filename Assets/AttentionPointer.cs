using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AttentionPointer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform cameraVector;
    public Vector3 cameraOffset;
    public GameObject focusObject;
    public SetParent setParent;
    public TextManager textManager;
    public DataManager dataManager;

    void Start()
    {
        
        gameObject.transform.position = cameraVector.transform.position + cameraOffset;
            
    }

    
    // Update is called once per frame
   

    public void nextPoint()
    {
        
        if (dataManager.attentionPosition[textManager.pageIndex - textManager.offs] == "")
        {
            gameObject.SetActive(false);

        }
        else
        {
            focusObject = GameObject.Find(dataManager.attentionPosition[textManager.pageIndex - textManager.offs]);        
            gameObject.SetActive(true);
        }
    }

    void Update()
    {

        if (textManager.onDisplay == true)
        {
            if (dataManager.attentionPosition[textManager.pageIndex - textManager.offs] == null)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
            gameObject.transform.position = focusObject.transform.position + cameraOffset;
            Vector3 rotation = gameObject.transform.position - focusObject.transform.position;
            gameObject.transform.LookAt(focusObject.transform);
        }
        
    }
}
