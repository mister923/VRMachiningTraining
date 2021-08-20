using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class objectSelection : MonoBehaviour
{
    public DataManager dataManager;
    private String[] movingObjects;

    public LinearMotion linearMotion;
    public TextManager textManager;

    public GameObject movedObject;
      
    void Start()
    {
      
    }
    

    public void changeObject()
    {
        //linearMotion.movingObject.SetActive(false);
        if(dataManager.objectSelection[textManager.pageIndex] != "")
        {
            movedObject = GameObject.Find(dataManager.objectSelection[textManager.pageIndex-textManager.offs]);
            //Rigidbody[] rblist = new Rigidbody[]();
            Rigidbody[] rblist = movedObject.GetComponentsInChildren<Rigidbody>();
            foreach(Rigidbody rb in rblist)
            {
                rb.isKinematic = true;
            }
            linearMotion.setMovingObject(movedObject);
            linearMotion.movingObject.SetActive(true);
            
        }
        else
        {
            Debug.Log("No Selection or Change");
            //linearMotion.movingObject.SetActive(false);
        }
        

    }

}
    
  
