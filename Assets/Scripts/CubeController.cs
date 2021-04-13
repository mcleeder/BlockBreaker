using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Rigidbody breakerCube;
    public Vector3 forwardVector;
    public float forwardSpeed;
    public static bool Go = false;

    void Awake()
    {
        breakerCube = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GoForward(Go);
    }

    private void GoForward(bool Go)
    {
        if (Go)
        {
            breakerCube.transform.position += Vector3.Normalize(forwardVector) * Time.deltaTime * forwardSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TopBlocks")
        {
            forwardVector = Vector3.Reflect(forwardVector, Vector3.forward);
        }
        if (other.tag == "SideBlocks")
        {
            forwardVector = Vector3.Reflect(forwardVector, Vector3.right);
        }
        if (other.tag == "Blocks")
        {
            Destroy(other.gameObject);
            forwardVector = Vector3.Reflect(forwardVector, Vector3.forward);
        }
        if (other.tag == "EndBlock")
        {
            forwardVector = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            float rand = Random.Range(-0.02f, 0.02f);
            forwardVector = Vector3.Reflect(forwardVector, new Vector3(0f, 0f, 1f) + new Vector3(0f, 0f, rand));
        }
    }
}
