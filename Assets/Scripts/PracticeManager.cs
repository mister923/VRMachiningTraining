using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PracticeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCreator boxCreator;
    public GameObject wcsBox;
    public GameObject wcsTriad;
    [SerializeField] private GameObject wcsTriadTest;
    public Vector3 tableRegion;
    public Vector3 displayRegion;
    public int correctCorner;
    public int correctCornerCt = 0;
    [SerializeField] private GCodeProcessor Tormach;

    //Raycast Selection

    [SerializeField]
    private Transform rHand;
    [SerializeField]
    private Transform lHand;
    public GameObject currentSelected;

    
    private enum Axis { x, y, z };



    public TextMeshProUGUI axisSelector;
    private Dictionary<string, string> selectionText = new Dictionary<string, string> {
        { "start", "Select the proper corner to locate the Work Coordiante System" },
        { "errorCorner", "The corner selected does not match the Coordiante System established in the CAM program" },
        {"correct", "Correct"}
    };

    void Start()
    {
        //GeneratePracticeSelectorBox(Resources.Load("WCS Box") as GameObject, new Vector3(.3f, .1f, .3f), Resources.Load("Sphere") as GameObject, tableRegion, Vector3.zero);
        
    }

    

    public void RunUp()
    {
        GenerateCAMStock(new Vector3(.3f, .1f, .3f), new Vector3(25, -25, 0));
        GeneratePracticeSelectorBox(Resources.Load("WCS Box") as GameObject, new Vector3(.3f, .1f, .3f), Resources.Load("Sphere") as GameObject, tableRegion, Vector3.zero);
        ZoneCreator();
        
    }

    public void GeneratePracticeSelectorBox(GameObject newStock, Vector3 size, GameObject cornerObject, Vector3 instLocation, Vector3 rotation)
    {
        GameObject practiceBox = Instantiate(newStock, instLocation, Quaternion.Euler(rotation));
        practiceBox.transform.localScale = size;
        boxCreator.VertexPoints(practiceBox.GetComponent<MeshFilter>(), BoxCreator.InstPoints.all, cornerObject, Quaternion.Euler(0,0,0));
        
        //boxCreator.VertexPoints(practiceBox.GetComponent<MeshFilter>(), BoxCreator.InstPoints.single, wcsTriad, cornerLocation);

    }

    private void GenerateCAMStock(Vector3 size, Vector3 rotation)
    {
        correctCorner = Random.Range(0, 7);
        GameObject stockBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Placing box in desired location
        stockBox.transform.position = displayRegion;
        stockBox.name = "TestBox";
        stockBox.transform.localScale = size;
        stockBox.transform.rotation = Quaternion.Euler(rotation);        
        //Visual Highlight
        GameObject highlight = Instantiate(Resources.Load("HighlightNP" )) as GameObject;
        TextMeshProUGUI text =stockBox.AddComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        text.text = "Stock";        
        highlight.transform.position = new Vector3(stockBox.transform.position.x, stockBox.transform.position.y -.15f, stockBox.transform.position.z);
        highlight.transform.rotation = stockBox.transform.rotation;
        highlight.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        boxCreator.VertexPoints(stockBox.GetComponent<MeshFilter>(), BoxCreator.InstPoints.single, wcsTriad, Quaternion.Euler(0, 0, 0), correctCorner);

    }

    public void Refresh()
    {
        DestroyImmediate(GameObject.Find("TestBox"));
        DestroyImmediate(GameObject.Find("WCS Box(Clone)"));
        DestroyImmediate(GameObject.Find("Highlighter(Clone)"));
        DestroyImmediate(GameObject.Find("Stock Box"));
        ResetVals();
        RunUp();
    }

    


    public void CheckCornerSelection(GameObject selectedObject, int correctIndex)
    {
        int selectedIndex = int.Parse(selectedObject.name);
        if (correctIndex == selectedIndex)
        {
            selectedObject.GetComponent<MeshRenderer>().material.color = Color.green;
            selectedObject.transform.localScale = selectedObject.transform.localScale + new Vector3(.5f, .5f, .5f);
            axisSelector.text = "Correct! Try another example.";
            correctCornerCt += 1;
            Refresh();

        }
        else
        {
            axisSelector.text = "Incorrect, make sure that the WCS have a matching location. Try again!";
            Refresh();
        }
    }

    public void CheckPlanes(GameObject xPlane, GameObject yPlane, GameObject zPlane)
    {
        bool xSideCorrect = false;
        bool ySideCorrect = false;
        bool zSideCorrect = false;

        Bounds x=xPlane.transform.gameObject.GetComponent<MeshRenderer>().bounds;
        Bounds y = yPlane.transform.gameObject.GetComponent<MeshRenderer>().bounds;
        Bounds z = zPlane.transform.gameObject.GetComponent<MeshRenderer>().bounds;
        Bounds correctX = GameObject.Find("XContactTest").GetComponent<MeshRenderer>().bounds;
        Bounds correctY = GameObject.Find("YContactTest").GetComponent<MeshRenderer>().bounds;
        Bounds correctZ = GameObject.Find("ZContactTest").GetComponent<MeshRenderer>().bounds;

        Debug.Log(z.Intersects(correctX));
        Debug.Log(z.Intersects(correctY));
        Debug.Log(z.Intersects(correctZ));

        Debug.Log(x.Intersects(correctX));
        Debug.Log(x.Intersects(correctY));
        Debug.Log(x.Intersects(correctZ));

        Debug.Log(y.Intersects(correctX));
        Debug.Log(y.Intersects(correctY));
        Debug.Log(y.Intersects(correctZ));

        if (x.Intersects(correctX))
        {
            xSideCorrect = true;
        }
        if (y.Intersects(correctY))
        {
            ySideCorrect = true;
        }
        if (z.Intersects(correctZ))
        {
            zSideCorrect = true;
        }

        if(xSideCorrect && ySideCorrect && zSideCorrect)
        {
            touchoffText.text = "Correct! All faces have been indicated properly";
        }
        else
        {
            touchoffText.text = "Not all sides are correct" + "X Axis: " + xSideCorrect.ToString() + "Y Axis: " + ySideCorrect.ToString() + "Z Axis: " + zSideCorrect.ToString();
        }

    }

     public void SubmitToCheck()
    {
        if (currentSelected == null)
        {
            axisSelector.text = "A corner must be selected before submitting";
        }
        else
        {
            CheckCornerSelection(currentSelected, correctCorner);
        }
    }

    public void SubmitSidesToCheck()
    {
        boxCreator.VertexPoints(GameObject.Find("TestBox").GetComponent<MeshFilter>(), BoxCreator.InstPoints.single, wcsTriadTest, Quaternion.identity, correctCorner);
        CheckPlanes(xSelected, ySelected, zSelected);
    }

    // Update is called once per frame

    public void ResetVals()
    {
        isSelected = false;
        currentSelected = null;
    }

    bool isSelected = false;
    public GameObject xSelected;
    public GameObject ySelected;
    public GameObject zSelected;
      
    IEnumerator CornerSelction(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject != null)
            {
                if (hit.transform.gameObject.layer == 9)
                {
                    //hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = enterColor;
                    Debug.Log(hit.transform.gameObject.name);
                    if (OVRInput.Get(OVRInput.Button.One) && !isSelected)
                    {
                        currentSelected = hit.transform.gameObject;
                        hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = boxCreator.enterColor;
                        isSelected = true;
                    }
                    if (OVRInput.Get(OVRInput.Button.One) && isSelected)
                    {
                        currentSelected.GetComponent<MeshRenderer>().material.color = boxCreator.defaultColor;
                        hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = boxCreator.enterColor;
                        currentSelected = hit.transform.gameObject;
                        isSelected = true;

                    }
                }
            }
        }
        yield return null;
    }

    [SerializeField]
    GameObject goodhitZone;
    [SerializeField]
    GameObject mediumhitZone;
    [SerializeField]
    GameObject wrongZone;

    public void ZoneCreator()
    {
        GameObject stockbox = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stockbox.name = "Stock Box";
        stockbox.transform.localScale = new Vector3(.3f, .3f, .3f);
        stockbox.gameObject.transform.parent = GameObject.Find("Xholder").transform;
        stockbox.transform.localPosition = new Vector3(0, 0, -.2f);
        boxCreator.VertexPoints(stockbox.GetComponent<MeshFilter>(), BoxCreator.InstPoints.single, goodhitZone, Quaternion.Euler(Vector3.zero), correctCorner);
        boxCreator.VertexPoints(stockbox.GetComponent<MeshFilter>(), BoxCreator.InstPoints.single, mediumhitZone, Quaternion.Euler(Vector3.zero), correctCorner);
        boxCreator.VertexPoints(stockbox.GetComponent<MeshFilter>(), BoxCreator.InstPoints.all, wrongZone, Quaternion.Euler(Vector3.zero));
        Transform[] cornercomponents = stockbox.transform.GetComponentsInChildren<Transform>();
        foreach(Transform t in cornercomponents)
        {
            if (t != stockbox.transform)
            {
                t.gameObject.GetComponent<MeshRenderer>().enabled=false;
                

            }
        }

    }

    /*
    void OnTriggerEnter(Collider cornerRegion)
    {
        Collider endmill = Tormach.activeTool.GetComponent<Collider>();
        if (cornerRegion.tag == "HitRegion")
        {
            cornerRegion.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void OnTriggerExit(Collider cornerRegion)
    {
        Collider endmill = Tormach.activeTool.GetComponent<Collider>();
        if (cornerRegion.tag == "HitRegion")
        {
            cornerRegion.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    */

    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject rButton;
    IEnumerator SideSideSelection(Ray ray, int axis)
    {
        Dictionary<int, Color> axiscolor = new Dictionary<int, Color>()
        {
            {0, Color.red},
            {1, Color.green},
            {2, Color.blue}
        };

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject != null && hit.transform.gameObject.layer == 10)
            {
                if (hit.transform.gameObject.layer == 10)
                {
                    if (OVRInput.Get(OVRInput.Button.One))
                    {
                        if(hit.transform.gameObject !=xSelected && hit.transform.gameObject != ySelected && hit.transform.gameObject != zSelected)
                        {
                            hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = axiscolor[axis];
                            if (axis == 0) { xSelected = hit.transform.gameObject; }
                            if (axis == 1) { ySelected = hit.transform.gameObject; }
                            if (axis == 2) { zSelected = hit.transform.gameObject; axisProgress = 0;  StopCoroutine(SideSideSelection(ray, 0));  }
                        }
                        
                    }
                }
            }
        }        
               
        yield return null;
    }

    public TextMeshProUGUI touchoffText;
    public void TouchOffActive()
    {
        if(axisProgress ==0)
        {
            axisProgress = 1;
        }
        else
        {
            axisProgress = 0;
        }
    }

    public int axisProgress=0;
    public int axisInProg;
    void Update()
    {
        Vector3 pos = rHand.position;
        Vector3 rot = rHand.forward;
        Ray ray = new Ray(pos, rot);
        StartCoroutine(CornerSelction(ray));

        if (xSelected == null && ySelected == null && zSelected == null)
        {
            axisInProg = 0;
            touchoffText.text = "Select the appropriate side to indicate the X axis from.";
        }

        if (xSelected != null && ySelected == null && zSelected == null)
        {
            axisInProg = 1;
            touchoffText.text = "Select the appropriate side to reference the Y axis from.";
        }

        if (xSelected != null && ySelected != null && zSelected == null)
        {
            axisInProg = 2;
            touchoffText.text = "Select the appropriate side to reference the Z axis from.";
        }

        if (axisProgress ==1)
        {
            StartCoroutine(SideSideSelection(ray, axisInProg));
        }
       
        


    }
}

