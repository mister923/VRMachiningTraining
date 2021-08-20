using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonColor : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    public void ChangeColor()
    {
        if (gameObject.GetComponent<Image>().color != gameObject.GetComponent<Button>().colors.selectedColor) 
        {
            gameObject.GetComponent<Image>().color = gameObject.GetComponent<Button>().colors.selectedColor;
        }
        else
        {
            gameObject.GetComponent<Image>().color = gameObject.GetComponent<Button>().colors.normalColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
