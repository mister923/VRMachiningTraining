using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Panel currentPanel = null;
    private List<Panel> panelHistory = new List<Panel>();
    [SerializeField] private Panel StepDisplay;
    public BucketUpdate bucketUpdate;

    // Start is called before the first frame update
    void Start()
    {
        SetupPanels();

    }

    private void SetupPanels()
    {
        Panel[] panels = GetComponentsInChildren<Panel>();

        foreach (Panel panel in panels)
            panel.Setup(this);

        currentPanel.Show();
    }

    public void GoToPrevious()
    {
        if (panelHistory.Count == 0)
        {
            OVRManager.PlatformUIConfirmQuit();
            return;
        }

        int lastIndex = panelHistory.Count - 1;
        SetCurrent(panelHistory[lastIndex]);
        panelHistory.RemoveAt(lastIndex);
    }

    public void SetCurrent(Panel newPanel)
    {
        currentPanel.Hide();
        if (newPanel == StepDisplay)
        {
            bucketUpdate.BucketUpdater();
        }
        currentPanel = newPanel;        
        currentPanel.Show();
        
    }

    public void SetCurrentWithHistory(Panel newPanel)
    {
        panelHistory.Add(currentPanel);
        SetCurrent(newPanel); 
        

    }


    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
            GoToPrevious();
    }
}
