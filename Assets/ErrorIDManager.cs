using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class ErrorIDManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> AllErrorCases;
    public List<GameObject> RemainingErrorCases;
    public GameObject ErrorCaseParent;
    public GameObject activeCase;
    public Tool toolDisplay;

    [SerializeField] private MenuManager MenuManager;
    [SerializeField] private Panel alignmentErrors;
    [SerializeField] private Panel toolErrors;
    [SerializeField] private Panel fixtureErrors;
    [SerializeField] private Panel completedReview;
    [SerializeField] private Panel ErrorStartPage;

    public ErrorCaseManager ECM;



    [SerializeField] private TMP_Text indicator1;
    [SerializeField] private TMP_Text indicator2;
    [SerializeField] private TMP_Text indicator3;
    [SerializeField] private TMP_Text indicator4;

    public ReportCardDisplay ReportCard;

    [SerializeField] private GameObject PathViz;
    void Start()
    {
        
        foreach(Transform errorCase in ErrorCaseParent.transform)
        {
            if(errorCase.gameObject != ErrorCaseParent)
            {
                AllErrorCases.Add(errorCase.gameObject);
                errorCase.gameObject.SetActive(false);
                ECM.ChangeErrorCase();
            }
        }
        RemainingErrorCases = AllErrorCases;

        activeCase = AllErrorCases[UnityEngine.Random.Range(0, AllErrorCases.Count)];
        activeCase.gameObject.SetActive(true);
        ECM.ChangeErrorCase();
        RemainingErrorCases.Remove(activeCase);     
        
        
      
    }


    private Dictionary<string, Panel> errorDirectory = new Dictionary<string, Panel> { };
    public List<Panel> selectedPaths;
    public void SelectedPaths(Panel selectedError)  
    {
        selectedPaths.Add(selectedError);
    }

    public void NextCase()
    {
        if(RemainingErrorCases.Count >= 1)
        {
            activeCase.gameObject.SetActive(false);
            activeCase = RemainingErrorCases[UnityEngine.Random.Range(0, RemainingErrorCases.Count)];
            activeCase.gameObject.SetActive(true);
            PathViz.transform.SetParent(activeCase.transform);
            PathViz.transform.localPosition = Vector3.zero;            
            MenuManager.SetCurrentWithHistory(ErrorStartPage);
            RemainingErrorCases.Remove(activeCase);
            toolDisplay.SetActiveTool(activeCase.GetComponent<ErrorElements>().activateTool);
            toolDisplay.SetOpTool(activeCase.GetComponent<ErrorElements>().OPtoolInfo);



        }
        else
        {
            MenuManager.SetCurrentWithHistory(completedReview);
        }
        ResetErrors();
    }
    private void ResetErrors()
    {
        gameObject.GetComponent<ErrorElements>().IncorrectCornerError = false;
        gameObject.GetComponent<ErrorElements>().OrientationError = false;
        gameObject.GetComponent<ErrorElements>().ZZeroError = false;
        gameObject.GetComponent<ErrorElements>().WrongToolError = false;
        gameObject.GetComponent<ErrorElements>().ToolDataError = false;
        gameObject.GetComponent<ErrorElements>().MeasurementError = false;
        gameObject.GetComponent<ErrorElements>().CollisionError = false;
        gameObject.GetComponent<ErrorElements>().ClampingError = false;
        gameObject.GetComponent<ErrorElements>().ParralelismError = false;
    }
    public void PathRouter()
    {
        if (selectedPaths.Count == 1)
        {
            if (gameObject.GetComponent<ErrorElements>().inputFlag)
            {
                MenuManager.SetCurrentWithHistory(completedReview);
                ReportCard.Evaluate();

            }
            else
            {
                MenuManager.SetCurrentWithHistory(selectedPaths[0]);
            }
            
        }
        else
        {
            if (selectedPaths.Count == 0)
            {
                MenuManager.GoToPrevious();
            }
            else
            {
                if (MenuManager.currentPanel == selectedPaths[0])
                {

                    selectedPaths.Remove(selectedPaths[0]);
                    MenuManager.SetCurrentWithHistory(selectedPaths[0]);
                }
                else
                {
                    MenuManager.SetCurrentWithHistory(selectedPaths[0]);
                }
            }
        }
       
       

    }

    public Dictionary<string, bool> ErrorEvaluation()
    {
        Dictionary<string, bool> reportCard = new Dictionary<string, bool>();
        ErrorElements submission = gameObject.GetComponent<ErrorElements>();
        ErrorElements caseCorrect = activeCase.GetComponent<ErrorElements>();

        // True = answered correctly, False= incorrect answer

        if(submission.ClampingError == caseCorrect.ClampingError) { reportCard.Add("clamping", true); } else { reportCard.Add("clamping", false);}
        if (submission.CollisionError == caseCorrect.CollisionError) { reportCard.Add("collision", true); } else { reportCard.Add("collision", false); }
        if (submission.ParralelismError == caseCorrect.ParralelismError) { reportCard.Add("parralelism", true); } else { reportCard.Add("parralelism", false); }

        if (submission.WrongToolError == caseCorrect.WrongToolError) { reportCard.Add("wrongtool", true); } else { reportCard.Add("wrongtool", false); }
        if (submission.ToolDataError == caseCorrect.ToolDataError) { reportCard.Add("tooldata", true); } else { reportCard.Add("tooldata", false); }
        if (submission.MeasurementError == caseCorrect.MeasurementError) { reportCard.Add("measurement", true); } else { reportCard.Add("measurement", false); }

        if (submission.IncorrectCornerError == caseCorrect.IncorrectCornerError) { reportCard.Add("IncorrectCorner", true); } else { reportCard.Add("IncorrectCorner", false); }
        if (submission.OrientationError == caseCorrect.OrientationError) { reportCard.Add("OrientationError", true); } else { reportCard.Add("OrientationError", false); }
        if (submission.ZZeroError == caseCorrect.ZZeroError) { reportCard.Add("ZZeroError", true); } else { reportCard.Add("ZZeroError", false); }
        
        return reportCard;
    }

    //Jank Code to Log Submissions from button selection
    public void cornerToggler() { gameObject.GetComponent<ErrorElements>().IncorrectCornerError = true; }
    public void OrientationToggler() { gameObject.GetComponent<ErrorElements>().OrientationError = true; }
    public void ZZeroToggler() { gameObject.GetComponent<ErrorElements>().ZZeroError = true; }
    public void WrongToolToggler() { gameObject.GetComponent<ErrorElements>().WrongToolError = true; }
    public void ToolDataToggler() { gameObject.GetComponent<ErrorElements>().ToolDataError = true; }
    public void MeasurementToggler() { gameObject.GetComponent<ErrorElements>().MeasurementError = true; }
    public void CollisionToggler() { gameObject.GetComponent<ErrorElements>().CollisionError = true; }
    public void ClampingToggler() { gameObject.GetComponent<ErrorElements>().ClampingError = true; }
    public void ParralelismToggler() { gameObject.GetComponent<ErrorElements>().ParralelismError = true; }

    // Update is called once per frame
    void Update()
    {
        indicator1.text = indicator2.text = indicator3.text = indicator4.text = activeCase.name;

    }
}
