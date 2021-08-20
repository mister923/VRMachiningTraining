using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideTable : MonoBehaviour
{
    // Start is called before the first frame update]   
    
    private Renderer render;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private Transform partsparent;
    private GameObject enteringOb;
    private GameObject leavingOb;
    public List<GameObject> onTable;
    [SerializeField]
    private GameObject lHands;
    [SerializeField]
    private GameObject rHands;

    void Start()
    {
        render = GetComponent<Renderer>();
        render.enabled = false;  
    }

    private void OnTriggerEnter(Collider bop)
    {

        if (bop.gameObject.tag == "Hands")
        {
            foreach (GameObject item in onTable)
            {
                item.gameObject.transform.SetParent(partsparent);
            }
        }

        if (bop.gameObject.tag == "Part")
        {
            onTable.Add(bop.gameObject);
        }

        if (bop.gameObject.tag == "Part" | bop.gameObject.tag == "Hands") { render.enabled = true;}
        
             
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Part")
        {
            onTable.Add(col.gameObject);
        }              
    } 
    
    private void OnTriggerExit(Collider bop)
    {
        render.enabled = false;
        onTable.Remove(bop.gameObject);
        foreach (GameObject item in onTable)
        {
            item.gameObject.transform.SetParent(parent);
        }       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
