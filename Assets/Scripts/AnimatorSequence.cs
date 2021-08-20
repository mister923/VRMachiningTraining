using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class AnimatorSequence : MonoBehaviour
{
    public DataManager dataManager;
    public LinearMotion linearMotion;
    public TextManager textManager;
    private string[] waypointParents;
    public GameObject waypointGO;
    public String waypointParent;
    
    // Start is called before the first frame update
  
    public void animateIndexer()
    {        
        waypointParent = dataManager.animatorSequence[textManager.pageIndex];        
        waypointGO = GameObject.Find(waypointParent);
        
        //Debug.Log(waypointGO.name);
        //Debug.Log(waypointGO);
        if (waypointGO == null)
        {
            Debug.Log("Cant find");
        }
        else
        {
            linearMotion.WaypointFollow(waypointGO.transform);
            
        }
    }
}
