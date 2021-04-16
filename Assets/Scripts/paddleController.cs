using UnityEngine;

public class paddleController : MonoBehaviour
{

    public Rigidbody rb;
    private float movement;
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (movement != 0)
        {
            rb.AddForce(new Vector3(movement, 0f, 0f) * Time.deltaTime * moveSpeed, ForceMode.VelocityChange);
        }

    }
}
