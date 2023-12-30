using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Transform endTeleport;
    private Transform player;

    [SerializeField]
    //private CameraController camControl;
    private bool InTrigger = false;
    private float timer ;
    private float timeThreshold  = 1f;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update(){
        if (InTrigger){
            timer += Time.deltaTime;

            if (timer > timeThreshold){
                TeleportToEnd();
                StartCoroutine(RotateCamera());
            }
        }

    }
    private void OnTriggerEnter(){
        InTrigger = true;
        timer = 0f;
    }
    private void OnTriggerExit(){
        InTrigger = false;
        timer = 0f;
    }


    private void TeleportToEnd()
    {

        Vector3 endDimensions = endTeleport.transform.lossyScale;

        float randomX = Random.Range(endTeleport.transform.position.x - endDimensions.x / 2, endTeleport.transform.position.x + endDimensions.x / 2);
        float randomY = Random.Range(endTeleport.transform.position.y - endDimensions.y / 2, endTeleport.transform.position.y + endDimensions.y / 2);
        float randomZ = Random.Range(endTeleport.transform.position.z - endDimensions.z / 2, endTeleport.transform.position.z + endDimensions.z / 2);
        player.transform.position = new Vector3(randomX, randomY, randomZ);
        
    }

    private IEnumerator RotateCamera(){
        yield return new WaitForSeconds(.1f);

        //camControl.SetCameraToAngle(endTeleport.transform.eulerAngles.y);

        //TODO 
        //FInd a workaround for this
    }
}
