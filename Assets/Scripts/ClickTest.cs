using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClickTest : MonoBehaviour, IPointerClickHandler
{
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        float force = 100;
        Vector3 worldPoint = new Vector3();
        Vector2 screenPoint = new Vector2();
        // Get the click position from Event.
        screenPoint.x = pointerEventData.pressPosition.x;
        screenPoint.y = cam.pixelHeight - pointerEventData.pressPosition.y;
        worldPoint = cam.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, cam.nearClipPlane));
        Vector3 dir = worldPoint - transform.position;

        // We then get the opposite (-Vector3) and normalize it
        dir = -dir.normalized;
        // And finally we add force in the direction of dir and multiply it by force. 
        // This will push back the object
        GetComponent<Rigidbody>().AddForce(dir * force, ForceMode.Force);
    }
}