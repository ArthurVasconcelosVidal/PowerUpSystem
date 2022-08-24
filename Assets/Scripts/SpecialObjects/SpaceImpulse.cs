using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceImpulse : MonoBehaviour{
    [SerializeField] SpaceImpulse targetSpaceImpulse;
    [SerializeField] string playerTag;
    [SerializeField] float velocity;
    [SerializeField] float timeToEnd;

    GravityManager playerGravity;

    /*
        TODO:
            - Neutralize gravity force and apply a force to the center
            - Disable any movement or powerUp (Make easy to disable specific inputs (like disable a button))
            - Make the movement to the next object (can use spherical interpolation to move between two points)
            - Make the posibility of unlimited stop points in the movement (can make a trail if space impulse)
            - Disable gravity point after a certain quantity of time or when the player press a button to cancel the space impulse
            - make the movement Smooth
            - get some animation to no gravity space
    */
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(playerTag)){}
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag(playerTag)){}
    }

    void EnablePlayerComponents(GameObject player, bool enable = true){

    }

    void DisableGravity(){

    }
}
