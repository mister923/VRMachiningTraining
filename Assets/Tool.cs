using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tool : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject activeTool;
    public GameObject selectedOpTool;

    [SerializeField] private GameObject defaultTool;

    public GameObject toolLibrary;
    [SerializeField] private TMP_Dropdown toolLibraryDropdown;

    [SerializeField] private GameObject toolPosition;

    [SerializeField] private TMP_Text activetoolLength;
    [SerializeField] private TMP_Text activeDiameter;
    [SerializeField] private TMP_Text activeType;
    [SerializeField] private TMP_Text activeFlutes;

    [SerializeField] private TMP_Text toolLength;
    [SerializeField] private TMP_Text diameter;
    [SerializeField] private TMP_Text type;
    [SerializeField] private TMP_Text flutes;


    void Start()
    {
        ListToolLibrary();
        SetActiveTool(defaultTool);
        SetOpTool(toollist[1]);
    }

    public void SetActiveTool(GameObject tool)
    {
        activeTool = tool;
        activeTool.transform.SetParent(toolPosition.transform);
        activeTool.transform.localPosition = Vector3.zero;
        activetoolLength.text = "Length: " + tool.GetComponent<ToolInfo>().ToolLength.ToString();
        activeDiameter.text ="Diameter: " + tool.GetComponent<ToolInfo>().ToolDiameter.ToString();
        activeFlutes.text = "Flutes: " + tool.GetComponent<ToolInfo>().Flutes.ToString();
        activeType.text ="Type: "+  tool.GetComponent<ToolInfo>().typeTool.ToString();        

    }

    public int ToolVal;
    public void SetOpTool(GameObject tool)
    {
        selectedOpTool = tool;
        toolLength.text = "Length: " + tool.GetComponent<ToolInfo>().ToolLength.ToString();
        diameter.text = "Diameter: " + tool.GetComponent<ToolInfo>().ToolDiameter.ToString();
        flutes.text= "Flutes: " + tool.GetComponent<ToolInfo>().Flutes.ToString();
        type.text = "Type: " + tool.GetComponent<ToolInfo>().typeTool.ToString();

    }

    private List<GameObject> toollist = new List<GameObject>();
    public void ListToolLibrary()
    {

        foreach (Transform parent in toolLibrary.transform)
        {
            if(parent != toolLibrary)
            {
                toollist.Add(parent.gameObject);
                toolLibraryDropdown.options.Add(new TMP_Dropdown.OptionData(parent.GetComponent<ToolInfo>().Name));
            }            

        } 
    }

    public void DropdownChange(TMP_Dropdown drop)
    {
        activeTool.transform.SetParent(toolLibrary.transform);
        activeTool.transform.localPosition = Vector3.zero;        
        SetActiveTool(toollist[drop.value]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
