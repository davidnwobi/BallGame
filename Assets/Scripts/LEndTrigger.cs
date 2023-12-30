using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class LEndTrigger : MonoBehaviour
{
    private Rigidbody rb;
    private bool InTrigger = false;
    private bool playerMoved = true;
    private float timer;
    [SerializeField]
    private float timeThreshold  = 2f;
    [SerializeField]
    private float positionTolerance  = 20f;
    
    private Vector3 prevPosition;
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            InTrigger = true;
        }
        timer = 0f;
    }
    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider is the player
        if (other.CompareTag("Player"))
        {
            // Set the condition to false when the player exits the trigger
            InTrigger = false;
        }
        timer = 0f;
    }
    
    void Start(){
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        prevPosition =  rb.position;
        
    }

    void Update(){
        if (InTrigger){

            timer += Time.deltaTime;
            if (timer >= timeThreshold){
                FindObjectOfType<GameManager>().CompleteLevel();
            }
        }
        
    }

}
