using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public Vector3 direction;

    Vector3 stepVector;
    Rigidbody2D rigidBody;
    PlayerContoller playerController;


    // Use this for initialization
    void Start()
    {
        //
        speed = 6;
        lifeTime = 4;
        direction = new Vector3(-1, 0, 0);
        Destroy(gameObject, lifeTime);
        rigidBody = GetComponent<Rigidbody2D>();
        stepVector = speed * direction.normalized;
        //
    }

    void FixedUpdate()
    {
        rigidBody.velocity = stepVector;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.tag == "shield")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "rogue")
        {
            playerController = GameObject.Find("Rogue_03").GetComponent<PlayerContoller>();
            if (playerController.energy >= 15)
            {
                playerController.energy = playerController.energy - 15;
                Destroy(gameObject);
            }
            else
            {
                playerController.kill();
                Destroy(gameObject);
            }
        }
    }
}