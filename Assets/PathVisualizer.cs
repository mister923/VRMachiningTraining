using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PathVisualizer : MonoBehaviour
{
    // Start is called before the first frame update
    private TubeRenderer pathViz;
    public List<Vector3> pathCoordinates;
    private TextAsset coordinateInput;
    public DataManager dataManager;
    [SerializeField] public bool Inches;
    



    void Start()
    {
        
        RefreshPath();
        
    }

    public bool lhCoordAdjust;
    void SetupCoordinates()
    {
        var starttime = Time.time;
        string[] coordinateString = coordinateInput.text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        foreach (string line in coordinateString)
        {
            
            string[] values = line.Split(new string[] { ";", "," }, StringSplitOptions.None);            
            try
            {
                var x = Convert.ToSingle(values[0]);
                var y = Convert.ToSingle(values[1]);
                var z = Convert.ToSingle(values[2]);
                Vector3 coord = new Vector3(x, y, z);
                if (lhCoordAdjust)
                {
                    coord = new Vector3(coord.x*-1, coord.y, coord.z);
                }
                if (Inches)
                {
                    coord = coord * .0254f;
                }            
                pathCoordinates.Add(coord);
            }
            catch
            {
                Debug.Log(values);
            }
            
        }
        var endtime = Time.time;
        Debug.Log(endtime - starttime);

    }

    public void RefreshPath()
    {
        pathCoordinates.Clear();
        coordinateInput = dataManager.gcodeFile;
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        SetupCoordinates();

        //pathViz = gameObject.GetComponent<TubeRenderer>();        
                                                                          
        VisualizePath(pathCoordinates);
    }
    void VisualizePath(List<Vector3> coordinates)
    {
        //gameObject.GetComponent<MeshRenderer>().enabled = true;
        //pathViz.SetPositions(coordiantes);

        
        gameObject.SetActive(true);
        var line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = coordinates.Count;
        line.SetPositions(coordinates.ToArray());
        line.startWidth=.002f;
        line.endWidth = .002f;
        
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
