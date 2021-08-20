using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToggleShow : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject canvas;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
        {
            ToggleActive();
        }
            

    }

    public void ToggleActive()
    {
        
            if (canvas.activeInHierarchy == true)
            {
                canvas.SetActive(false);
            }
            else
            {
                 canvas.SetActive(true);
            }         
    
    }
}
