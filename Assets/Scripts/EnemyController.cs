using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rgb2d;
    private Animator animator;

    public Slider slider;
    public Text energyText;

    private GameObject newAttack;
    public GameObject attack;

    public float energy;
    private bool right;

    public float nextFire = 20;
    //public AudioSource audio;


    public float myTime;
    public float fireDelta = 0.5F;

    // Use this for initialization
    void Start()
    {
        right = true;
        speed = -1f;
        energy = 100;
        rgb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        slider.value = energy;
        energyText.text = energy.ToString();
        myTime = myTime + Time.deltaTime;

        /* if (newAttack == null && myTime > nextFire)
         {
             nextFire = myTime + fireDelta;
             
             Vector3 positionShield = new Vector3(transform.position.x - 1, transform.position.y + 1, -1);
           
             newAttack = Instantiate(attack, positionShield, transform.rotation);
 
             animator.SetTrigger("jump");
             nextFire = nextFire - myTime;
             myTime = 0.0F;
             newAttack = null;
         }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 vector = new Vector2(speed, 0);
        rgb2d.velocity = vector;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk") && Random.value < 1f / (60f * 3f))
        {
            animator.SetTrigger("jump");
            Vector3 positionShield = new Vector3(transform.position.x - 1, transform.position.y + 1, -1);

            newAttack = Instantiate(attack, positionShield, transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Flip();
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