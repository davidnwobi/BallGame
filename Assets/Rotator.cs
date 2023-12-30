using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float sentitivity = 0.1f;
    public Transform playerposition;
    public Vector2 turn;

    public float pLerp = 0.2f;
    public float rLerp = 0.2f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;

    }
    void FixedUpdate()
    {

        ManageCursor();
        Vector3 targetPos = playerposition.position;
        transform.position = Vector3.Lerp(transform.position, targetPos, pLerp);
        turn.x += Input.GetAxis("Mouse X") * sentitivity;
        turn.y += Input.GetAxis("Mouse Y") * sentitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        Quaternion targetRot = Quaternion.Euler(-turn.y, turn.x, 0);
        transform.localRotation = Quaternion.Lerp(transform.rotation, targetRot, rLerp);

    }

    void ManageCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
