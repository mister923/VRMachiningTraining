using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public enum ToolType { flat, ball, drill, chamfer, radius, cDrill, edgefinder, probe };

    public float ToolLength;
    public string Name;
    public int Flutes;
    public float ToolDiameter;
    public int OperationNumber;    
    public ToolType typeTool;
    
    
}
