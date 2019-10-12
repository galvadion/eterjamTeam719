using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyBehaviour>()?.DetectSight(this.GetComponentInParent<Transform>().parent);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<EnemyBehaviour>()?.LosingCollider();
    }
}
