using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextManager TextManager;
    [SerializeField] private objectSelection objectSelection;
    [SerializeField] private AnimatorSequence animatorSequence;
    [SerializeField] private TotalMotion totalMotion;
    [SerializeField] private SetParent SetParent;
    [SerializeField] private ParentingController ParentingController;
    [SerializeField] private Arrow arrow;
    [SerializeField] private AttentionPointer attentionPointer;
    void Start()
    {
        
    }
    public void BucketUpdater()
    {
        TextManager.nextText();
        objectSelection.changeObject();
        animatorSequence.animateIndexer();
        totalMotion.destinationIterator();
        SetParent.nextHighlight();
        ParentingController.childParentIterator();
        arrow.nextPoint();
        attentionPointer.nextPoint();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
