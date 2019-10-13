using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public Animator anim;
    public Vector2 movement;
    public GameObject flashlight;

    private GameManager gM;
    private Rigidbody2D rb;

    private void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        if (movement.y == 1)
        {
            flashlight.transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (movement.y == -1)
        {
            flashlight.transform.rotation = Quaternion.Euler(0,0,180);
        }
        else if (movement.x == -1)
        {
            flashlight.transform.rotation = Quaternion.Euler(0,0,90);
        }
        else if (movement.x == 1)
        {
            flashlight.transform.rotation = Quaternion.Euler(0,0,270);  	
        }
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gM.Death();
        }
    }
}
