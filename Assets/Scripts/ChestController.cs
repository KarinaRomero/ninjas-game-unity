using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    Animator animator;
    public Text ChestText;

    // Use this for initialization
    void Start()
    {
        ChestText.text = " ";
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "rogue")
        {
            ChestText.text = "+10";
            
        }
    }
}