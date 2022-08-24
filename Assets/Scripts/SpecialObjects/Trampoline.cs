using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour{
    [SerializeField] string playerTag;
    [SerializeField] JumpFeature jumpFeature;

    void Start() {

    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag(playerTag)){
        }
    }

    void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag(playerTag)){

        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(playerTag)){
            Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
            GravityManager gravityManager = GetComponent<GravityManager>();
            //gravityManager.gra
            //rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnTriggerExit(Collider other) {
        
    }

}
