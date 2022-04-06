using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowProjectile : MonoBehaviour{
    Rigidbody rigidbody;
    public Vector3 ArrowDirection { get; set;}
    float DragForce { get; set;}
    float ShootForce { get; set;}
    bool init = false;
    
    public void Initialize(Vector3 arrowDirection, float dragForce, float shootForce){
        ArrowDirection = arrowDirection;
        DragForce = dragForce;
        ShootForce = shootForce;
        init = true;
    }

    // Start is called before the first frame update
    void Start(){
        rigidbody = GetComponent<Rigidbody>();
        Debug.Log($"Arrow direction: {ArrowDirection} || Drag Force: {DragForce} || ShootForce: {ShootForce}");
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(init)
            ApplyArrowForce(ArrowDirection, ShootForce, DragForce);
    }

    public void ApplyArrowForce(Vector3 arrowDirection, float arrowStartForce, float dragForce){
        rigidbody.velocity = arrowDirection.normalized * arrowStartForce;
        rigidbody.drag = dragForce;
    }
}
