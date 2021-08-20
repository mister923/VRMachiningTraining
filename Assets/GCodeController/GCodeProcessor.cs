using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GCodeProcessor : MonoBehaviour

{
    public bool g20=true; //inches 
    public GameObject workOrigin;
    public Tool toolManager;
    public GameObject activeTool;
    
    [SerializeField]
    public TextMeshProUGUI xDRO;
    [SerializeField]
    public TextMeshProUGUI yDRO;
    [SerializeField]
    public TextMeshProUGUI zDRO;



    private void Start()
    {
        activeTool=toolManager.activeTool;
        setWorkCoordinateX();
        setWorkCoordinateY();
        setWorkCoordinateZ();
        
    }

       



    public void setWorkCoordinateX()
    {
        
        workOrigin.transform.position= new Vector3(activeTool.transform.position.x, workOrigin.transform.position.y, workOrigin.transform.position.z);

    }

    public void setWorkCoordinateY()
    {
        workOrigin.transform.position = new Vector3(workOrigin.transform.position.x, workOrigin.transform.position.y, activeTool.transform.position.z);
    }

    public void setWorkCoordinateZ()
    {
        workOrigin.transform.position = new Vector3(workOrigin.transform.position.x, activeTool.transform.position.y, workOrigin.transform.position.z);
    }

    public void updateDRO()
    {
        activeTool = toolManager.activeTool;
        double g20toggle;
        if (g20)
        {
            g20toggle = 39.370;
        }
        else
        {
            g20toggle = 1;
        }
        double distanceX = activeTool.transform.position.x - workOrigin.transform.position.x;
        double distanceY = -(activeTool.transform.position.z - workOrigin.transform.position.z);
        double distanceZ = activeTool.transform.position.y - workOrigin.transform.position.y;
        xDRO.text = (distanceX* g20toggle).ToString("0.0000");
        yDRO.text = (distanceY*g20toggle).ToString("0.0000");
        zDRO.text = (distanceZ*g20toggle).ToString("0.0000");


    }

    void Update()
    {
                
        updateDRO();
        


    }
}
