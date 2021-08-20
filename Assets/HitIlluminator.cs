using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitIlluminator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //public GCodeProcessor Tormach;
    public MeshRenderer priorRenderer;
    void OnTriggerEnter(Collider cornerRegion)
    {
        
        Debug.Log(cornerRegion.gameObject.name);
        //Collider endmill = Tormach.activeTool.GetComponent<Collider>();
        if (cornerRegion.CompareTag("HitRegion"))
        {
            if (priorRenderer == null)
            {
                priorRenderer = cornerRegion.gameObject.GetComponent<MeshRenderer>();
            }        
            
            cornerRegion.gameObject.GetComponent<MeshRenderer>().enabled = true;
            
            if(priorRenderer != cornerRegion.gameObject.GetComponent<MeshRenderer>())
            {
                priorRenderer.enabled = false;
            }
            priorRenderer= cornerRegion.gameObject.GetComponent<MeshRenderer>();
        }
    }

    void OnTriggerExit(Collider cornerRegion)
    {

        //Collider endmill = Tormach.activeTool.GetComponent<Collider>();
        Debug.Log(cornerRegion.gameObject.name);
        if (cornerRegion.CompareTag("HitRegion"))
        {
            
            cornerRegion.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
