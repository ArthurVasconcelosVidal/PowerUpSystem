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
    [SerializeField] Vector4 teste = Vector4.one;
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


    void ArrowDecay() => actualDragForce = dragForce;

    IEnumerator ArrowMovement(){


        yield return null;
    }
    
    Vector3 PositionAtQuadraticBezierCurve(float t, Vector3 p1, Vector3 p2, Vector3 p3) => (((1 - t) * (1 - t)) * p1) + (2 * (1 - t) * t * p2) + (t * t) * p3;
    
    void OnDrawGizmos() {
        Gizmos.color = new Color(.5f,0,1,0.5f);

        Gizmos.DrawSphere(PositionAtQuadraticBezierCurve(0, transform.position * teste.x, transform.position + (transform.forward * teste.y), transform.position + (transform.forward * teste.z) - (transform.up * teste.w) ), 0.2f);
        Gizmos.DrawSphere(PositionAtQuadraticBezierCurve(.1f, transform.position * teste.x, transform.position + (transform.forward * teste.y), transform.position + (transform.forward * teste.z) - (transform.up * teste.w) ), 0.2f);
        Gizmos.DrawSphere(PositionAtQuadraticBezierCurve(.2f, transform.position * teste.x, transform.position + (transform.forward * teste.y), transform.position + (transform.forward * teste.z) - (transform.up * teste.w) ), 0.2f);
        Gizmos.DrawSphere(PositionAtQuadraticBezierCurve(.3f, transform.position * teste.x, transform.position + (transform.forward * teste.y), transform.position + (transform.forward * teste.z) - (transform.up * teste.w) ), 0.2f);
        Gizmos.DrawSphere(PositionAtQuadraticBezierCurve(.4f, transform.position * teste.x, transform.position + (transform.forward * teste.y), transform.position + (transform.forward * teste.z) - (transform.up * teste.w) ), 0.2f);
        Gizmos.DrawSphere(PositionAtQuadraticBezierCurve(.5f, transform.position * teste.x, transform.position + (transform.forward * teste.y), transform.position + (transform.forward * teste.z) - (transform.up * teste.w) ), 0.2f);
        Gizmos.DrawSphere(PositionAtQuadraticBezierCurve(.6f, transform.position * teste.x, transform.position + (transform.forward * teste.y), transform.position + (transform.forward * teste.z) - (transform.up * teste.w) ), 0.2f);
        Gizmos.DrawSphere(PositionAtQuadraticBezierCurve(.7f, transform.position * teste.x, transform.position + (transform.forward * teste.y), transform.position + (transform.forward * teste.z) - (transform.up * teste.w) ), 0.2f);
        Gizmos.DrawSphere(PositionAtQuadraticBezierCurve(.8f, transform.position * teste.x, transform.position + (transform.forward * teste.y), transform.position + (transform.forward * teste.z) - (transform.up * teste.w) ), 0.2f);
        Gizmos.DrawSphere(PositionAtQuadraticBezierCurve(.9f, transform.position * teste.x, transform.position + (transform.forward * teste.y), transform.position + (transform.forward * teste.z) - (transform.up * teste.w) ), 0.2f);
        Gizmos.DrawSphere(PositionAtQuadraticBezierCurve(1f, transform.position * teste.x, transform.position + (transform.forward * teste.y), transform.position + (transform.forward * teste.z) - (transform.up * teste.w) ), 0.2f);
    }
    public void ApplyArrowForce(Vector3 arrowDirection, float arrowStartForce, float dragForce){
        rigidbody.velocity = arrowDirection.normalized * arrowStartForce;
        rigidbody.drag = dragForce;
    }
}
