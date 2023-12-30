using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    // Start is called before the first frame update
    private Vector3 offset;
    private bool behind = true;
    void Start()
    {
        offset =  player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - offset;
    }

    public void CamBehind(bool _behind){
        if (_behind){
            offset.z = Math.Abs(offset.z);
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                0,
                transform.eulerAngles.z
            );
        }
        else{
            offset.z = -Math.Abs(offset.z);
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                180,
                transform.eulerAngles.z
            );
        }
    }
}
