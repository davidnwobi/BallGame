using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionIntensityController : MonoBehaviour
{
    public Material targetMaterial;
    public float intensityIncreaseRate = 0.1f;
    private Color targetColor;
    public float upperIntensityLimit = 2.2f;
    public float lowerIntesityLimit = 0f;
    private float intensityTracker = 0f;

    private Color originalEmissionColor;
    void Awake(){
        originalEmissionColor = targetMaterial.GetColor("_EmissionColor");
    }
    void Start(){
        targetColor = targetMaterial.GetColor("_EmissionColor");
    }
    void Update()
    {
        if (intensityTracker>=upperIntensityLimit){
            intensityIncreaseRate = -Mathf.Abs(intensityIncreaseRate);
        }
        else if(intensityTracker<=lowerIntesityLimit){
            intensityIncreaseRate = Mathf.Abs(intensityIncreaseRate);
        }
        ChangeEmissionIntensity();
    }

    void ChangeEmissionIntensity(){
        
        if (targetMaterial != null)
        {

            Color currentEmission = targetMaterial.GetColor("_EmissionColor");
            Color newEmission = currentEmission + targetColor * intensityIncreaseRate;
            intensityTracker += intensityIncreaseRate;
            targetMaterial.SetColor("_EmissionColor", newEmission);

        }
    }

    void OnDisable(){
        ResetEmissionIntensity();
    }
    public void ResetEmissionIntensity(){
        targetMaterial.SetColor("_EmissionColor", originalEmissionColor);
    }

    
}
