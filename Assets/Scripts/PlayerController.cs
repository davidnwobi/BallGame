using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private PlayerMotor motor;

    [SerializeField]
    private GameObject PlayerTracker;
    
    public float m_Thrust = 20f;
    
    void Awake(){
        PlayerTracker.transform.position = transform.position;
    }
    void Start(){
        motor = GetComponent<PlayerMotor>();
    }

    void FixedUpdate(){
        
        

        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");
        Vector3 force = (_xMov * PlayerTracker.transform.right.normalized + _zMov * PlayerTracker.transform.forward.normalized) * m_Thrust;
        motor.Move(force);
    }


}
