using UnityEngine;

public class MotionControl : MonoBehaviour
{
    public float speed = .1f;

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xMove, 0.0f, zMove);

        transform.position += moveDirection* speed;

    }
}
