using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Movement")]

    private bool isDetected = false, isInSight = false;
    public LayerMask fovLayer;
    public int speed;
    public Transform characterLocation;

    void Update()
    {
        if (isDetected)
        {
            Vector3 thisObject = this.GetComponent<Transform>().position;
            RaycastHit2D hit = Physics2D.Linecast(thisObject, characterLocation.position, fovLayer.value);
            //  Debug.DrawLine(characterLocation.position, thisObject,new Color32(255,0,0,255),10f);
            if (hit.collider.tag == "Player")
            {
                this.GetComponent<NavMeshAgent>().isStopped = false;
                isInSight = true;
                this.GetComponent<NavMeshAgent>().SetDestination(characterLocation.position);
            }
            else
            {
                isInSight = false;
            }

        }
        else
        {
            this.GetComponent<NavMeshAgent>().isStopped = true;
        }


    }

    public void DetectSight(Transform characterLocation)
    {
        this.characterLocation = characterLocation;
        isDetected = true;
    }

    public void LosingCollider()
    {
        isDetected = false;
        isInSight = false;
    }
}
