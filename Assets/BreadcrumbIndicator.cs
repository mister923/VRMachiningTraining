using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreadcrumbIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public TextManager textManager;
    public MenuManager menuManager;
    [SerializeField] private int StartRange;
    [SerializeField] private int EndRange;
    [SerializeField] private Panel desiredPanel;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(textManager.pageIndex >= StartRange && textManager.pageIndex <= EndRange || menuManager.currentPanel==desiredPanel)
        {
            gameObject.GetComponent<Image>().color = gameObject.GetComponent<Button>().colors.selectedColor;
        }
        else
        {
            gameObject.GetComponent<Image>().color = gameObject.GetComponent<Button>().colors.normalColor;
        }
    }
}
