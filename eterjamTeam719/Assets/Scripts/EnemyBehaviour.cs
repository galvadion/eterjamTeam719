﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Movement")]

    private bool isDetected = false, isInSight = false, isLightning = false;
    public LayerMask fovLayer;
    public int speed;
    public Transform characterLocation;
    public Transform[] randomPoints;
    

    void Update()
    {
        if (isDetected)
        {
            Vector3 thisObject = this.GetComponent<Transform>().position;
            RaycastHit2D hit = Physics2D.Linecast(thisObject, characterLocation.position, fovLayer.value);
            //  Debug.DrawLine(characterLocation.position, thisObject,new Color32(255,0,0,255),10f);
            if (hit.collider.tag == "Player")
            {
                this.GetComponent<NavMeshAgent>().speed = 2;
                this.GetComponent<NavMeshAgent>().acceleration = 5;
                this.GetComponent<NavMeshAgent>().angularSpeed = 120;
                this.GetComponent<NavMeshAgent>().isStopped = false;
                isInSight = true;
                Invoke("startMovement", .5f);
            }
            else
            {
                isInSight = false;
            }
        }
        else
        {
            if (!isLightning)
            {
                this.GetComponent<NavMeshAgent>().isStopped = true;
            }

        }
    }

    public void startMovement()
    {
        this.GetComponent<NavMeshAgent>().SetDestination(characterLocation.position);
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

    public void CrazyMove()
    {
        if (!isDetected)
        {
            isLightning = true;
            Transform randomVector = randomPoints[Random.Range(0, randomPoints.Length)];
            this.GetComponent<NavMeshAgent>().speed = 50;
            this.GetComponent<NavMeshAgent>().acceleration = 50;
            this.GetComponent<NavMeshAgent>().angularSpeed = 260;
            this.GetComponent<NavMeshAgent>().isStopped = false;
            this.GetComponent<NavMeshAgent>().SetDestination(randomVector.position);
        }
    }

    public void StopCrazyMovement()
    {
        isLightning = false;
        this.GetComponent<NavMeshAgent>().isStopped = true;
    }
}
