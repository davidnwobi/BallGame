using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlatform : MonoBehaviour
{
    [SerializeField]private GameObject limit1;
    [SerializeField]private GameObject limit2;
    private float speed;

    private bool goingToLimit2 = true;
    private Rigidbody rb;
    void Start(){
        rb = GetComponent<Rigidbody>();
        RandomStart();
    }
    //Start at some random position between limit1 and limit2;
    //Go to limit2 
    void FixedUpdate(){
        if (goingToLimit2){
            Vector3 vecBetweenLimits = limit2.transform.position-limit1.transform.position;
            Vector3 normalVector = vecBetweenLimits.normalized;
            rb.MovePosition(transform.position + normalVector*Time.deltaTime*speed);
            if ((transform.position-limit1.transform.position).sqrMagnitude >= vecBetweenLimits.sqrMagnitude){
                goingToLimit2 = false;
                speed = Random.Range(2f,5f);
            }
            
        }
        else{
            Vector3 vecBetweenLimits = -limit2.transform.position+limit1.transform.position;
            Vector3 normalVector = vecBetweenLimits.normalized;
            rb.MovePosition(transform.position + normalVector*Time.deltaTime*speed);
            if ((transform.position-limit2.transform.position).sqrMagnitude >= vecBetweenLimits.sqrMagnitude){
                goingToLimit2 = true;
                speed = Random.Range(2f,5f);
            }
        }
        
    }

    void RandomStart()
    {
        float minX = Mathf.Min(limit1.transform.position.x, limit2.transform.position.x);
        float maxX = Mathf.Max(limit1.transform.position.x, limit2.transform.position.x);
        float randomX = Random.Range(minX, maxX);
        Vector3 startPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        transform.position = startPosition;

        goingToLimit2 = Random.value < 0.5f;
        speed = Random.Range(2f,5f);
    }


}
