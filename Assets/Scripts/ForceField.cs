using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public float maxForce = 100f;
    [SerializeField] private GameObject MidPoint;
    [SerializeField] private GameObject TopLeft;
    private float radius;

    void Start()
    {
        radius = Vector3.Distance(MidPoint.transform.position, TopLeft.transform.position);
    }
    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Calculate the force based on the distance from the center
            float distance = Vector3.Distance(MidPoint.transform.position, other.transform.position);
            float normalizedDistance = Mathf.Clamp01(distance / radius);
            float force = (1 - Mathf.Pow(normalizedDistance,8)) * maxForce;

            // Repel the object
            Vector3 repelDirection = (other.transform.position - MidPoint.transform.position).normalized;
            rb.AddForce(repelDirection * force, ForceMode.Force);
        }
    }
}
