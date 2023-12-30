using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 force = Vector3.zero;
    private float rotationSpeed = 5f;

    [SerializeField] private Rigidbody collisionRb = null;
    
    [SerializeField]
    private float dynamicFriction = 10;
    [SerializeField]
    private float staticFriction = 25;

    [SerializeField] private float radius = 1;

    public float ANGULAR_VELOCITY_DAMPING = 0.9f;

    public bool updateAnggularVelocity = true;
    private bool isColliding = false;
    void Start(){
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;


    }
    public void Move(Vector3 _force)
    {
        force = _force;
    }

    private void PerformMovement(){ 
        
        //force = adjustForcetoSlope(force);
        Debug.Log(force);
        rb.AddForce(force, ForceMode.Force);
        if (updateAnggularVelocity) UpdateAngularVelocityWithForce();
        force = Vector3.zero;
    }


    private void FixedUpdate()
    {
        if(isColliding){
            PerformMovement();
            if (updateAnggularVelocity) AngularVelocityDecay();
        }
        
        
    }

    void OnCollisionEnter(Collision collision)
    {
        collisionRb = collision.rigidbody;
        isColliding = true;
    }
    void OnCollisionExit(Collision collision)
    {
        collisionRb = null;
        isColliding = false;

    }
    void OnCollisionStay(Collision collision)
    {
        if (collisionRb == null) {
            collisionRb = collision.rigidbody;
            isColliding = true;
        }
    }

    Vector3 adjustForcetoSlope(Vector3 force){
        RaycastHit hit;
        float forceMagnitude = force.magnitude;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.2f)){
            var slopeRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            var forceDirection = slopeRotation * force.normalized;
            force = forceDirection * forceMagnitude;
        }
        return force;

    }

    void UpdateAngularVelocityWithForce(){
        if (rb.velocity == Vector3.zero){
            rb.angularVelocity = Vector3.zero;
            return;
        }
        Vector3 rotationSpeed = rb.velocity/radius;

        rb.angularVelocity = Quaternion.Euler(0f, 90f, 0f) *  rotationSpeed;
    }
    void AngularVelocityDecay(){
        if (rb.velocity.magnitude < 0.1f){
            rb.angularVelocity = Vector3.zero;
            return;
        }
        rb.angularVelocity = rb.angularVelocity * ANGULAR_VELOCITY_DAMPING;
    }

}
