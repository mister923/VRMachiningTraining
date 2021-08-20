using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisplayChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public MenuManager MenuManager;
    public Panel stepDisplay;
    public TextManager text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManager.currentPanel == stepDisplay)
        {
            text.onDisplay = true;            
        }
        else
        {
            text.onDisplay = false;
        }
    }
}
