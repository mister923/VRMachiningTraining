using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TotalMotion : MonoBehaviour
{
    public GCodeProcessor gcode;
    public DataManager dataManager;

    public float speed;
    [SerializeField] private float defaultSpeed = .01f;
    
    private int axis;    

    //Work Coordinate System  Needed to Offset 
    //public GameObject workCoordinate;
    public GameObject tool;

    [SerializeField]
    private GameObject XMovement;
    [SerializeField]
    private GameObject YMovement;
    [SerializeField]
    private GameObject ZMovement;

    public int coordinateIndex = 0;

    // Shared Menu Index Reference
    public TextManager textManager;

    //Independent Position Toggle
    public bool independentCoords = false;

    public int pause;
    public int pausex;
    public int pausey;
    public int pausez;

    [SerializeField]
    private Vector3 xStartingPos;
    [SerializeField]
    private Vector3 yStartingPos;
    [SerializeField]
    private Vector3 zStartingPos;

    public PathVisualizer path;


    public decimal[] xyzdestination = new decimal[3];

    private Vector3 destination = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        
        pause = 0;
        xStartingPos = XMovement.transform.position;
        yStartingPos = YMovement.transform.position;
        zStartingPos = ZMovement.transform.position;

    }

    //File Preparation
    
       
    public void setAxis(int newAxis)
    {
        axis = newAxis;
    }

    public void allMotion(int directionID)
    {
        if (axis == 0)
        {
            Vector3 moveDirection = new Vector3(directionID, 0.0f, 0.0f);
            XMovement.transform.position += moveDirection * speed;
        }
        if (axis == 1)
        {
            Vector3 moveDirection = new Vector3(0.0f, 0.0f, directionID);
            YMovement.transform.position += moveDirection * speed;
        }
        if (axis == 2)
        {
            Vector3 moveDirection = new Vector3(0.0f, directionID, 0.0f);
            ZMovement.transform.position += moveDirection * speed;
        }

    }

    public void SetSpeed(float newspeed)
    {
        speed = newspeed;
        
    }
    public int coordinatedIndex()
    {
        if (independentCoords)
        {
            coordinateIndex = gcodeLine;
        }
        else
        {
            coordinateIndex = textManager.pageIndex;
        }

        return coordinateIndex;
    }

    public void destinationIterator()
    {
        destination.x = gcode.activeTool.transform.position.x -(dataManager.tormachX[textManager.pageIndex - textManager.offs]) - gcode.workOrigin.transform.localPosition.x;
        destination.y = gcode.activeTool.transform.position.z - Convert.ToSingle(dataManager.tormachY[textManager.pageIndex - textManager.offs]) - gcode.workOrigin.transform.localPosition.z - XMovement.transform.localPosition.z;

        destination.z = Convert.ToSingle(dataManager.tormachZ[textManager.pageIndex - textManager.offs]) + gcode.workOrigin.transform.position.y;
        
        if(dataManager.speed[textManager.pageIndex - textManager.offs] == null)
        {
            speed = defaultSpeed;
        }
        else
        {
            speed = Convert.ToSingle(dataManager.speed[textManager.pageIndex - textManager.offs]);
        }
        pause = 1;
        pausex = 1;
        pausey = 1;
        pausez = 1;
    }

    public void GCodeEnable()
    {
        pausex = 1;
        pausey = 1;
        pausez = 1;
        independentCoords = true;

    }

    public void TogglePause()
    {
        if (pause == 0)
        {
            pause = 1;
        }
        else
        {
            pause = 0;
        }

        
    }

    int gcodeLine = 0;

    // Update is called once per frame
    void Update()
    {
        int totalLength = path.pathCoordinates.Count;
        if (independentCoords)
        {
            speed = .2f;            
            destination.x = gcode.activeTool.transform.position.x - Convert.ToSingle((path.pathCoordinates[gcodeLine][0] / 25.4f)) - gcode.workOrigin.transform.localPosition.x; ;
            destination.y = gcode.activeTool.transform.position.z - Convert.ToSingle((path.pathCoordinates[gcodeLine][1] / 25.4f)) - gcode.workOrigin.transform.localPosition.z - XMovement.transform.localPosition.z; ;
            destination.z = Convert.ToSingle(path.pathCoordinates[gcodeLine][2] / 25.4f) + gcode.workOrigin.transform.position.y;
        }
       

        if (pause == 0)
        {
            pausex = 0;
            pausey = 0;
            pausez = 0;
        }

        Vector3 xdest = new Vector3(destination.x, xStartingPos.y, YMovement.transform.position.z);
        Vector3 ydest = new Vector3(yStartingPos.x, yStartingPos.y, destination.y);
        Vector3 zdest = new Vector3(zStartingPos.x, destination.z, zStartingPos.z);
        //Debug.Log("" + xdest + " " + ydest + " " +zdest);

        ZMovement.transform.position = Vector3.MoveTowards(ZMovement.transform.position, zdest, pausez * Time.deltaTime * speed);
        YMovement.transform.position = Vector3.MoveTowards(YMovement.transform.position, ydest, pausey * Time.deltaTime * speed);        
        XMovement.transform.position = Vector3.MoveTowards(XMovement.transform.position, xdest, pausex * Time.deltaTime * speed);

        
        
        

        if(independentCoords && gcodeLine < totalLength && XMovement.transform.position == xdest && YMovement.transform.position == ydest && ZMovement.transform.position == zdest)
        {
            gcodeLine += 1;
            pausex = 1;
            pausey= 1;
            pausez = 1;
        }
        
        
    }
}
