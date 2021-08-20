using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.ComponentModel.Design;

public class ErrorElements : MonoBehaviour
{

    //Catergory Errors
    private bool AlignmentError;
    private bool ToolLengthError;
    private bool FixturingError;

    //Error Types
    public bool IncorrectCornerError;
    public bool OrientationError;
    public bool ZZeroError;

    public bool WrongToolError;
    public bool ToolDataError;
    public bool MeasurementError;

    public bool CollisionError;
    public bool ClampingError;
    public bool ParralelismError;

    public TextAsset GCode;
    public GameObject OPtoolInfo;
    public GameObject activateTool;
    public GameObject StockBody;
    public int WCSStockCorner;
    public int WCSCAMCorner;


    [HideInInspector] public bool inputFlag;
    public void inputRecieved()
    {
        inputFlag = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (IncorrectCornerError || OrientationError || ZZeroError)
        {
            AlignmentError = true;
        }

        if (WrongToolError || ToolDataError || MeasurementError)
        {
            ToolLengthError = true;
        }

        if (CollisionError || ClampingError || ParralelismError)
        {
            FixturingError = true;
        }
    }
}

