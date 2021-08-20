using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartEnd : MonoBehaviour
{
    public TextManager textManager;
    // Start is called before the first frame update
    public int[] coordinateAlignment;
    public int[] toolSetter;
    public int[] TLOpaper;
    public int[] fixture;
    void Start()
    {
        
    }
    public void coordRange()
    {
       textManager.SetPageIndex(coordinateAlignment[0]);
       textManager.SetRangeVal(coordinateAlignment[1]);
        
    }

    public void toolRange()
    {
        textManager.SetPageIndex(toolSetter[0]);
        textManager.SetRangeVal(toolSetter[1]);

    }

    public void paperRange()
    {
        textManager.SetPageIndex(TLOpaper[0]);
        textManager.SetRangeVal(TLOpaper[1]);

    }

    public void fixtureRange()
    {
        textManager.SetPageIndex(fixture[0]);
        textManager.SetRangeVal(fixture[1]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
