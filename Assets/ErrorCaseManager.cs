using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorCaseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCreator boxCreator;
    public ErrorIDManager ErrorIDManager;
    public PracticeManager PracticeManager;
    public GameObject CAM;
    public DataManager DataManager;
    [SerializeField] private  Transform Xtable;

    [SerializeField] private GameObject PathViz;

    void Start()
    {
        gameObject.transform.SetParent(Xtable);
        ChangeErrorCase();
    }

    // Update is called once per frame
    public void SetErrorWCS()
    {
        
        MeshFilter activeStockMesh = ErrorIDManager.activeCase.GetComponent<ErrorElements>().StockBody.GetComponent<MeshFilter>();
        boxCreator.VertexPoints(activeStockMesh, BoxCreator.InstPoints.single, PracticeManager.wcsTriad, Quaternion.Euler(0,0,0), ErrorIDManager.activeCase.GetComponent<ErrorElements>().WCSStockCorner);     
        MeshFilter camMesh = CAM.GetComponent<MeshFilter>();
        boxCreator.VertexPoints(camMesh, BoxCreator.InstPoints.single, PracticeManager.wcsTriad, Quaternion.Euler(0, 0, 0), ErrorIDManager.activeCase.GetComponent<ErrorElements>().WCSCAMCorner);
        
    }

    public void UpdateToolpath()
    {
        TextAsset updatingGcode = ErrorIDManager.activeCase.GetComponent<ErrorElements>().GCode;     
        
        DataManager.gcodeFile = updatingGcode;
        PathViz.GetComponent<PathVisualizer>().RefreshPath();

    }

   public void ChangeErrorCase()
    {
        
        SetErrorWCS();
        UpdateToolpath();       

    }

    void Update()
    {
        
    }
}
