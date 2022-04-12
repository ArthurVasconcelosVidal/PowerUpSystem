using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StructLibrary;
public class BowProjectile : MonoBehaviour{
    Rigidbody rigidbody;
    public Vector3 ArrowDirection { get; set;}
    MinMaxFloat arrowTimeToDecay = new MinMaxFloat(0,4);
    float arrowIntensity;
    float actualDragForce= 0;
    [SerializeField] float dragForce;
    float ShootForce { get; set;}
    bool init = false;
    
    public void Initialize(Vector3 arrowDirection, MinMaxFloat MinMaxForce, float actualForce){
        ArrowDirection = arrowDirection;
        ShootForce = actualForce;

        arrowIntensity = Mathf.InverseLerp(MinMaxForce.Min, MinMaxForce.Max, actualForce);
        float timeToDecay = Mathf.Lerp(arrowTimeToDecay.Min, arrowTimeToDecay.Max, arrowIntensity);

        rigidbody = GetComponent<Rigidbody>();
        Invoke("ArrowDecay", timeToDecay);
        
        init = true;
        
        Debug.Log($"Lerp Result: {arrowIntensity} || Min value: {MinMaxForce.Min} || Max value: {MinMaxForce.Max} || ActualValue: {actualForce}");
        Debug.Log($"Time to Decay: {timeToDecay}");
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(init)
            ApplyArrowForce(ArrowDirection, ShootForce, actualDragForce);
    }

    void ArrowDecay() => actualDragForce = dragForce;

    public void ApplyArrowForce(Vector3 arrowDirection, float arrowStartForce, float dragForce){
        rigidbody.velocity = arrowDirection.normalized * arrowStartForce;
        rigidbody.drag = dragForce;
    }
}
