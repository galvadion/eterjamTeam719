using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header ("Movement")]
    public int speed;
    private bool isDetected, isInSight;
    public Transform characterLocation;

    void Update()
    {
        if(isDetected)
        {
            Debug.Log(characterLocation.transform.position);
        }

    }

    public void DetectSight(Transform characterLocation)
    {
        this.characterLocation = characterLocation;
        isDetected= true;
        Debug.Log(isDetected);
    }

    public void LosingCollider()
    {
        isDetected= false;
        Debug.Log(isDetected);
    }
}
