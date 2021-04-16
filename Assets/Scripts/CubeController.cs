using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Rigidbody breakerCube;
    public Vector3 forwardVector;
    public float forwardSpeed;
    public static bool Go = false;
    public AudioSource soundSides;
    public AudioSource soundTop;
    public AudioSource soundBlocks;
    public AudioSource soundPaddle;
    public GameObject gameManager;

    void Awake()
    {
        breakerCube = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Go)
        {
            GoForward();
        }

    }

    private void GoForward()
    {
        breakerCube.transform.position += Vector3.Normalize(forwardVector) * Time.deltaTime * forwardSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TopBlocks")
        {
            forwardVector = Vector3.Reflect(forwardVector, Vector3.forward);
            soundTop.PlayOneShot(soundTop.clip, .6f);
        }
        if (other.tag == "SideBlocks")
        {
            forwardVector = Vector3.Reflect(forwardVector, Vector3.right);
            soundSides.PlayOneShot(soundSides.clip, .6f);
        }
        if (other.tag == "Blocks")
        {
            Destroy(other.gameObject);
            forwardVector = Vector3.Reflect(forwardVector, Vector3.forward);
            soundBlocks.PlayOneShot(soundBlocks.clip, .6f);
        }
        if (other.tag == "EndBlock")
        {
            Go = false;
            gameManager.GetComponent<GameController>().gameLost = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            soundPaddle.PlayOneShot(soundPaddle.clip, .6f);
            float rand = Random.Range(-0.02f, 0.02f);
            forwardVector = Vector3.Reflect(forwardVector, new Vector3(0f, 0f, 1f) + new Vector3(0f, 0f, rand));
        }
    }
}
