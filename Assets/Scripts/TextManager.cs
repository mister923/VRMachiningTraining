using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public DataManager dataManager;
    //public TextAsset textFile;
    //private string[] lines;
   //ublic Text displayText; 
    public int pageIndex = 5;
    public Dictionary<string, int> sections = new Dictionary<string, int>();
    public MenuManager menu;
    public TextMeshProUGUI displayText;
    public int sectionRange;
    public int offs = 3;
    public bool onDisplay = false;

    // Start is called before the first frame update
    void Start()
    {
     
    }
    public void OnDisplayToggle()
    {
        if (onDisplay)
        {
            onDisplay = false;
        }
        else
        {
            onDisplay = true;
        }
    }
    public void nextText()
    {
        if(pageIndex <= sectionRange)
        {            
            
            if (pageIndex < dataManager.menuText.Count)
            {
                pageIndex += 1;
                /*
                if (dataManager.menuText[pageIndex-offs].StartsWith("%"))
                {
                    try
                    {
                        sections.Add(dataManager.menuText[pageIndex - offs], pageIndex);
                    }
                    catch (ArgumentException)
                    {
                        Debug.Log("Page already visited");

                    }
                    //pageIndex += 1;

                }
                */
                displayText.text = dataManager.menuText[pageIndex - offs];
            }

        }
        else
        {
            menu.GoToPrevious();
        }
       
    }

    public void backText()
    {
        if (pageIndex > 0)
        {
            pageIndex -= 1;
            /*
            if (dataManager.menuText[pageIndex].StartsWith("%"))
            {
                try
                {
                    sections.Add(dataManager.menuText[pageIndex - offs], pageIndex);
                    Debug.Log(sections);
                }
                catch (ArgumentException)
                {
                    Debug.Log("Page already visited");
                }
                //pageIndex -= 1;
            
            }
            */
            displayText.text = dataManager.menuText[pageIndex - offs];
        }
        else
        {
            menu.GoToPrevious();
        }

    }

    public void SetRangeVal(int sectionIndexRange)
    {
        sectionRange = sectionIndexRange;
    }

    public void SetPageIndex(int sectionIndexNum)
    {
        pageIndex = sectionIndexNum;
    }
}
