using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;


public class SetParent : MonoBehaviour
{
    // Start is called before the first frame update
    //public Transform transformParent;
    // public Transform originalParent;
    //public Component transformComponent;
    //public GameObject highlightObject;

    public DataManager dataManager;
    private string[] highlightOrder;
    public TextManager textManager;
    private Bounds defaultBounds;
    public GameObject upcomingHighlight;

    
   

    Vector3 parentOffset = Vector3.zero;
    public Vector3 dBoundCenter = Vector3.zero;
    public Vector3 dBoundSize =new Vector3(1f, 1f, 1f);

    void Start()
    {
        
        defaultBounds = new Bounds(upcomingHighlight.transform.position, dBoundSize);
        ChangeParent(defaultBounds);
        
    }

    public Bounds GetBounds(GameObject obj)
    {
        if (obj != null)
        {
            
            Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
          
            Debug.Log("# of Renderers: " + renderers.Length);
          
            Bounds combinedBounds = renderers[0].bounds;
            foreach (Renderer render in renderers)
            {       
                combinedBounds.Encapsulate(render.bounds);
                Debug.Log(combinedBounds);                       
            }
            
            return combinedBounds;
        }
        return defaultBounds;
    }

    public void ChangeParent(Bounds highlight)
    {
        gameObject.transform.position = highlight.center;
    }

    public void UpdatePosition(GameObject nextHighlight)
    {        
        ChangeParent(GetBounds(nextHighlight));    
        
    }
    
    public void nextHighlight()
    {        
        if (dataManager.highlightOrder[textManager.pageIndex-textManager.offs] == "")
        {
            gameObject.SetActive(false);

        }
        else
        {            
            upcomingHighlight = GameObject.Find(dataManager.highlightOrder[textManager.pageIndex - textManager.offs]);            
            UpdatePosition(upcomingHighlight);          
            gameObject.SetActive(true);
        }        
    }

    public void Update()
    {
        
    }
}
