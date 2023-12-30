using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityModifier : MonoBehaviour
{

    public float gravityModifier;
    private Rigidbody rb;
    const float g = 9.812f;

    private bool gravityChanged = true;
    private GravityModifier gravityModScript;
    const float UPPERLIMITg = 25f;
    const float LOWERLIMITg = 1f;
    private Vector3 prevVelocity;
    private Vector3 currentVelocity;
    private float  threshhold = 1e-3f;
    void Start(){
        gravityModScript = gameObject.GetComponent<GravityModifier>();
        gravityModScript.SetGravityModifier(Random.Range(LOWERLIMITg,UPPERLIMITg));
        rb = GetComponent<Rigidbody>();
        currentVelocity = prevVelocity = rb.velocity;
    }
    void FixedUpdate()
    {
        rb.AddForce(g*Vector3.down*gravityModifier,ForceMode.Acceleration);

        currentVelocity = rb.velocity;
        if (currentVelocity.y <= 0 && prevVelocity.y >= 0){
            gravityModScript.SetGravityModifier(Random.Range(LOWERLIMITg,UPPERLIMITg));
            gravityChanged = false;
        }
        else if (gravityChanged == false){
            gravityChanged = true;
        }
        prevVelocity = currentVelocity;
    }

    public void SetGravityModifier(float _gravityModValue){
        gravityModifier = _gravityModValue;
    }

    

    
}
