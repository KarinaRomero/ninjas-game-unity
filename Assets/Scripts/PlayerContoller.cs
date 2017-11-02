using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody2D rgb2d;
    private Animator animator;
    public float speedValue;
    private bool moveRigth;

    public Slider slider;
    public Text energyText;

    public float energy;

    public bool gameOver;
    public Text gameOverText;

    ChestController chestController;

    public GameObject shield;
    private GameObject newShield;
    public Transform ShieldSpawn;

    // Use this for initialization
    void Start()
    {
        gameOverText.text = "";
        gameOver = false;
        chestController = null;
        moveRigth = true;
        energy = 0;
        rgb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (gameOver)
        {
            gameOverText.text = "GAME OVER! :C";

            Destroy(gameObject);
        }
        else
        {
            if (Input.GetButton("Fire1") && newShield == null)
            {
                Vector3 positionShield =
                    new Vector3(transform.position.x + 2, transform.position.y + 1, transform.position.z);
                newShield = Instantiate(shield, positionShield, transform.rotation) as GameObject;
            }

            slider.value = energy;
            energyText.text = energy.ToString();
            if (chestController != null)
            {
                energy += 10;
            }
            chestController = null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (newShield == null && !gameOver)
        {
            float inputValue = Input.GetAxis("Horizontal");

            Vector2 speed = new Vector2(0, rgb2d.velocity.y);

            inputValue *= speedValue;

            speed.x = inputValue;

            rgb2d.velocity = speed;

            animator.SetFloat("Walking", speed.x);

            if (moveRigth && inputValue < 0)
            {
                moveRigth = false;

                Flip();
            }
            else if (!moveRigth && inputValue > 0)
            {
                moveRigth = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    public void SetControllerChest(ChestController chest)
    {
        chestController = chest;
    }

    public void kill()
    {
        animator.SetTrigger("Kill");
        gameOver = true;
    }
}