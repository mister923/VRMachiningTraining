using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text;


public class AnimationPointController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform waypointFolder;
    private int WaypointCreationIndex;
    private GameObject activeWaypointParent;
    [SerializeField]
    //private Canvas displayCanvas;
    public TMP_Dropdown parentdropdown;
    public TMP_Dropdown ptsDropdown;
    [SerializeField]
    private TextMeshProUGUI activeWPParentText;
    private List<string> wplist = new List<string>();
    private int parentsValue;
    private int pointsValue;
    public GameObject prefab;

    void Start()
    {
        ptsDropdown.gameObject.SetActive(false);
        ListWaypointParent();
        parentdropdown.onValueChanged.AddListener(delegate
        {
            DropdownChange(parentdropdown);
        });

        ptsDropdown.onValueChanged.AddListener(delegate
        {
            ptDropdownChange(ptsDropdown);
        });
    }

    void DropdownChange(TMP_Dropdown drop)
    {
        parentsValue = drop.value;
        SetActiveParent(parentsValue);
        ptsDropdown.gameObject.SetActive(true);
        
    }
    void ptDropdownChange(TMP_Dropdown drop)
    {
        pointsValue = drop.value;
        SetActiveParent(parentsValue);
    }

    public void CreateWaypointParent()
    {
        string parentName = "WaypointParent" + WaypointCreationIndex;
        GameObject newWaypoint = new GameObject();
        newWaypoint.name = parentName;        
        newWaypoint.transform.SetParent(waypointFolder);
        WaypointCreationIndex += 1;
        ListWaypointParent();
    }

   

    public void SetActiveParent(int selectedParent )
    {
        activeWaypointParent = GameObject.Find(wplist[selectedParent]);
        activeWPParentText.text = activeWaypointParent.name;
        List<string> waypoints = new List<string>();
        foreach (Transform point in activeWaypointParent.transform) { waypoints.Add(point.gameObject.name); }
        ptsDropdown.options.Clear();
        foreach (string val in waypoints)
        {
            ptsDropdown.options.Add(new TMP_Dropdown.OptionData(val));
        }

    }
    public void ListWaypointParent()
    {
        //Transform[] WaypointParents =waypointFolder.GetComponentsInChildren<Transform>();
        //Button Creation         
        foreach(Transform parent in waypointFolder) { wplist.Add(parent.gameObject.name);}
        parentdropdown.options.Clear();
        foreach( string option in wplist)
        {
            parentdropdown.options.Add(new TMP_Dropdown.OptionData(option));
        }    
    }

    public void CreatePoint()
    {
        
        if(activeWaypointParent != null)
        {
            string pointName = "Waypoint";
            Quaternion startang = new Quaternion().normalized;
            Vector3 startpos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - .5f, gameObject.transform.position.z - .1f);
            GameObject newWaypoint = Instantiate(prefab, startpos, startang);
            newWaypoint.name = pointName;
            newWaypoint.transform.SetParent(activeWaypointParent.transform);
            WaypointCreationIndex += 1;
        }
       
    }

    public void DeletePoint()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
