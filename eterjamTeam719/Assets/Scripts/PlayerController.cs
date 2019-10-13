using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Movement")]
    public float speed;

    private GameManager gM;

    private void Start()
    {
      gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.position += new Vector3((h * speed * Time.deltaTime), (v * speed * Time.deltaTime), 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gM.Death();
        }
    }
}
