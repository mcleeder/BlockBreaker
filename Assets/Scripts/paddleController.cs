using UnityEngine;

public class paddleController : MonoBehaviour
{

    public Rigidbody rb;
    private bool moveLeft;
    private bool moveRight;
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveRight = false;
        }
    }

    private void FixedUpdate()
    {
        if (moveLeft)
        {
            rb.AddForce(new Vector3(-1f, 0f, 0f) * Time.deltaTime * moveSpeed, ForceMode.VelocityChange);
        }
        if (moveRight)
        {
            rb.AddForce(new Vector3(1f, 0f, 0f) * Time.deltaTime * moveSpeed, ForceMode.VelocityChange);
        }
    }
}
