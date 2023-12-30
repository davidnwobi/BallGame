using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerController : MonoBehaviour
{   
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Transform Rotator;
    public float sentitivity = 0.1f;
    // Update is called once per frame
    float _xrot = 0f;
    void FixedUpdate()
    {
        if (playerTransform == null){
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        transform.position = playerTransform.position;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, Rotator.transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
