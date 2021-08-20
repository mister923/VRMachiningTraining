using UnityEngine;

public class MotionZ : MonoBehaviour
{
    public float speed = .1f;

    void Update()
    {
        float zMove = Input.GetAxis("Z");


        Vector3 moveDirection = new Vector3(0.0f, zMove, 0.0f);

        transform.position += moveDirection * speed;
    }
}
