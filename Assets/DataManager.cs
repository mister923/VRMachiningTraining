using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TextAsset dataFile;
    private string[] lines;
    public List<string> menuText;
    public List<string> highlightOrder;
    public List<string> objectSelection;
    public List<string> animatorSequence;
    public List<float> tormachX;
    public List<float> tormachY;
    public List<float> tormachZ;
    public List<string> attentionPosition;
    public List<string> setParent;
    public List<string> setChild;
    public List<string> speed;

    public TextAsset gcodeFile;

    
    
    void Start()
    {
        ReadFile();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadFile()
    {
        lines = dataFile.text.Split(new string[] { "\r\n", "\r", "\n", "\\n" }, StringSplitOptions.None);
        int i=0;
        foreach(string line in lines)
        {
            i += 1;
            if (i > 3)
            {
                string[] columns = line.Split(new string[] { "\t" }, StringSplitOptions.None);                
                menuText.Add(columns[1]);
                highlightOrder.Add(columns[2]);
                objectSelection.Add(columns[3]);
                animatorSequence.Add(columns[4]);                
                speed.Add(columns[5]);                
                tormachX.Add(Convert.ToSingle(columns[6]));
                tormachY.Add(Convert.ToSingle(columns[7]));
                tormachZ.Add(Convert.ToSingle(columns[8]));
                attentionPosition.Add(columns[9]);
                setParent.Add(columns[10]);
                setChild.Add(columns[11]);
            }
            else
            {
                i += 1;
            }
            
            

        }
    }
    
}
