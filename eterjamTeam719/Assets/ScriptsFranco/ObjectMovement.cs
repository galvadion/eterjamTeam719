using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FloorButton")
        {
            Debug.Log("Se abre una puerta...");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FloorButton")
        {
            Debug.Log("Se cierra la puerta...");
        }
    }
}
