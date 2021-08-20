using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    // Start is called before the first frame update
    public TextManager textManager;    
    public ErrorIDManager errorIDManager;
    public ErrorCaseManager ECM;
    public RangeManager rangeManager;
    [SerializeField] private int i;
    public int[][] publicCombo;
   
    void Awake()
    {
           int[][] a = new[] { rangeManager.wrongCorner, rangeManager.orientation, rangeManager.zero, rangeManager.wrongTool, rangeManager.toolData, rangeManager.measurement, rangeManager.collision, rangeManager.clamping, rangeManager.parralelism };
           publicCombo = a;
    }
    
    public void StepDisplayPosition()
    {
        textManager.SetPageIndex(publicCombo[i][0]);
        textManager.SetRangeVal(publicCombo[i][1]);
    }

    // Update is called once per frame
    private bool wcsComplete=false;
    void Update()
    {
        if(publicCombo[i][0]-1 <= textManager.pageIndex && textManager.pageIndex <= publicCombo[i][1])
        {
            foreach (Transform t in gameObject.transform)
            {
                t.gameObject.SetActive(true);
                errorIDManager.activeCase = gameObject;
                if (wcsComplete==false)
                {
                    ECM.ChangeErrorCase();
                    wcsComplete = true;
                }                               
            }
        }
        else
        {
            foreach (Transform t in gameObject.transform)
            {
                t.gameObject.SetActive(false); ;
            }
        }
    }
}
