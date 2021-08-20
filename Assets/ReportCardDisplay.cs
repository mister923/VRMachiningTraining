using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ReportCardDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public ErrorIDManager errorManager;
    public MenuManager Menu;

    [SerializeField] private GameObject corner;
    [SerializeField] private GameObject orient;
    [SerializeField] private GameObject zzero;

    [SerializeField] private GameObject wrongtool;
    [SerializeField] private GameObject tooldata;
    [SerializeField] private GameObject measurement;

    [SerializeField] private GameObject clamping;    
    [SerializeField] private GameObject collision;
    [SerializeField] private GameObject parralelism;



    public void Evaluate()
    {
        Dictionary<string,bool> eval = errorManager.ErrorEvaluation();
        
        //Debug.Log(eval["clamping"] + "2 " + eval["collision"] + " " + eval["parralelism"] + " " + eval["wrongtool"] + " " + eval["tooldata"] + " " + eval["measurement"] + );
        if(eval["clamping"] == true) { clamping.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100CHECK"); } else { clamping.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100RedX"); }
        if (eval["collision"] == true) { collision.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100CHECK"); } else { collision.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100RedX"); }
        if (eval["parralelism"] == true) { parralelism.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100CHECK"); } else { parralelism.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100RedX"); }

        if (eval["wrongtool"] == true) { wrongtool.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100CHECK"); } else { wrongtool.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100RedX"); }
        if (eval["tooldata"] == true) { tooldata.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100CHECK"); } else { tooldata.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100RedX"); }
        if (eval["measurement"] == true) { measurement.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100CHECK"); } else { measurement.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100RedX"); }

        if (eval["IncorrectCorner"] == true) { corner.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100CHECK"); } else { corner.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100RedX"); }
        if (eval["OrientationError"] == true) { orient.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100CHECK"); } else { orient.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100RedX"); }
        if (eval["ZZeroError"] == true) { zzero.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100CHECK"); } else { zzero.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("100RedX"); }


    }

    public void Update()
    {
        if(Menu.currentPanel != gameObject.GetComponent<Panel>())
        {
            corner.SetActive(false); orient.SetActive(false);  zzero.SetActive(false);  wrongtool.SetActive(false); tooldata.SetActive(false); measurement.SetActive(false); clamping.SetActive(false);  collision.SetActive(false); parralelism.SetActive(false);
        }
        else
        {
            corner.SetActive(true); orient.SetActive(true); zzero.SetActive(true); wrongtool.SetActive(true); tooldata.SetActive(true); measurement.SetActive(true); clamping.SetActive(true); collision.SetActive(true); parralelism.SetActive(true);
        }
    }
}
