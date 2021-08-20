using UnityEngine;

public class Motion : MonoBehaviour
{
    public float speed= .1f;
    
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        

        Vector3 moveDirection = new Vector3(-xMove, 0.0f, 0.0f);

        transform.position += moveDirection * speed;
    }
}
