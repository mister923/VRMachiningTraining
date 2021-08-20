using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowValues : MonoBehaviour
{
    public TextMeshProUGUI index;
    public TextMeshProUGUI highlighted;
    public TextMeshProUGUI animationParent;
    public TextMeshProUGUI selectedObject;
    public TextMeshProUGUI waypointInd;


    public TextManager textManager;
    public AnimatorSequence animator;
    public SetParent highlight;
    public objectSelection objects;
    public LinearMotion linear;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        index.text = "Index:" + " " + textManager.pageIndex;
        highlighted.text = "Highlighted:" + " " + highlight.upcomingHighlight;
        animationParent.text = "Waypoint:" + " " + animator.waypointGO;
        selectedObject.text = "Object Moving" + " " + objects.movedObject;
        waypointInd.text = "Waypoint Index " + linear.waypointIndex;
    }
}
