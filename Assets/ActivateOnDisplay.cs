using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActivateOnDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField] private GameObject toggledObject;
    public Panel[] activatedPanel;
    public MenuManager menuManager;

    // Update is called once per frame
    void Update()
    {
        if (Array.Exists(activatedPanel, element => element == menuManager.currentPanel))
        {
            toggledObject.SetActive(true);
        }
        else
        {
            toggledObject.SetActive(false);
        }
    }
}
