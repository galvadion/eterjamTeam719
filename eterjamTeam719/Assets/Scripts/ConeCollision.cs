using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyBehaviour>()?.DetectSight(this.GetComponentInParent<Transform>());
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<EnemyBehaviour>()?.LosingCollider();
    }
}
