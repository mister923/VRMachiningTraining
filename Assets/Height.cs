using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Height : MonoBehaviour
{
    
    [SerializeField]
    private GameObject movementPiece;
    [SerializeField]
    private GameObject objecttoMin;
    [SerializeField]
    private TextMeshProUGUI display;
    public float offsetCorrection;
    public enum AxisSelector {x,y,z};
    public AxisSelector axisSelector;
    private Vector3 initialMax;

       // Start is called before the first frame update
    void Start()
    {
        Vector3 initialMax = movementPiece.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (axisSelector == AxisSelector.x)
        {
            display.text = (initialMax.x- movementPiece.transform.position.x).ToString();
        }
        if (axisSelector == AxisSelector.y)
        {
            display.text = (initialMax.y - movementPiece.transform.position.y).ToString();
        }
        if (axisSelector == AxisSelector.z)
        {
            display.text = (initialMax.z - movementPiece.transform.position.z).ToString();
        }

    }
}
