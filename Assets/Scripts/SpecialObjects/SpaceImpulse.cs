using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceImpulse : MonoBehaviour{
    [SerializeField] GameObject targetPoint;
    [SerializeField] string playerTag;
    [SerializeField] float velocity;
    [SerializeField] float timeToEnd;

    GravityManager playerGravity;
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(playerTag)){}
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag(playerTag)){}
    }

    void EnablePlayerComponents(bool enable = true, GameObject player){
        
    }

    void DisableGravity(){

    }
}
