using UnityEngine;

public class MotionY : MonoBehaviour
{
    public float speed = .1f;

    void Update()
    {
        float yMove = Input.GetAxis("Vertical");


        Vector3 moveDirection = new Vector3(0.0f, 0.0f, yMove);

        transform.position += moveDirection * speed;
    }
}
