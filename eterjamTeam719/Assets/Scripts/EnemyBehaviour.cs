using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isDetected, isInSight;
    public LayerMask fovLayer;
    public int speed;

    public Transform characterLocation;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isDetected){
            Vector3 thisObject = this.GetComponent<Transform>().position;
            RaycastHit2D hit = Physics2D.Linecast(characterLocation.position,thisObject, fovLayer.value);
            Debug.DrawLine(characterLocation.position,thisObject,new Color32(255,0,0,255),10f);
            Debug.Log(thisObject);
            Debug.Log(characterLocation.position);
            Debug.Log(hit.collider);
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
