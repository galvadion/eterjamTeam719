using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isDetected, isInSight;
    public int speed;

    public Transform characterLocation;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDetected){
            Debug.Log(characterLocation.transform.position);
        }
    }

    public void DetectSight(Transform characterLocation){
        this.characterLocation = characterLocation;
        isDetected= true;
        Debug.Log(isDetected);
    }

    public void LosingCollider(){
        isDetected= false;
        Debug.Log(isDetected);
    }
}
