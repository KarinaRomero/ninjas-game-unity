using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rgb2d;
    private Animator animator;
    private GameObject newAttack;
    public GameObject attack;
    private bool right;

    public AudioClip AttackAudioClip;

    public AudioSource AttackAudioSource;

    private float currentTime;
    PlayerContoller playerController;


    //The time to spawn the object
    private float spawnTime;


    // Use this for initialization
    void Start()
    {
        currentTime = 0;
        spawnTime = Random.Range(0, 1);
        right = true;
        speed = -1f;
        rgb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AttackAudioSource = GetComponent<AudioSource>();
        playerController = GameObject.Find("Rogue_03").GetComponent<PlayerContoller>();
    }

    void Update()
    {
        //Counts up
        currentTime += Time.deltaTime;


        if (newAttack == null && currentTime >= spawnTime && right && !playerController.gameOver)
        {
            SpawnObject();
            currentTime = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("jump"))
        {
            animator.SetTrigger("walk");
        }
        
    }

    //Spawns the object and resets the time
    void SpawnObject()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            animator.SetTrigger("jump");
            Vector3 positionShield = new Vector3(transform.position.x - 1, transform.position.y + 1, -1);

            newAttack = Instantiate(attack, positionShield, transform.rotation);
            AttackAudioSource.PlayOneShot(AttackAudioClip);
        }
    }

    void FixedUpdate()
    {
        Vector2 vector = new Vector2(speed, 0);
        rgb2d.velocity = vector;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "attack")
        {
            Flip();
        }
    }

    void Flip()
    {
        speed *= -1;

        var s = transform.localScale;
        s.x *= -1;

        transform.localScale = s;
        if (!right)
        {
            right = true;
        }
        else
        {
            right = false;
        }
    }
}