using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class SpaceImpulse : MonoBehaviour{
    [SerializeField] SpaceImpulse targetSpaceImpulse;
    [SerializeField] bool insideSpaceImpulse;
    [SerializeField] string playerTag;
    [SerializeField] float velocity;
    [SerializeField] float gravityForce;
    [SerializeField] float timeToEnd;
    GravityManager playerGravity;

    /*
        TODO:
            - Neutralize gravity force and apply a force to the center (Feito)
            - Disable gravity point after a certain quantity of time or when the player press a button to cancel the space impulse (Feito)
            
            - Disable any movement or powerUp (Make easy to disable specific inputs (like disable a button))
            - Make the movement to the next object (can use spherical interpolation to move between two points)
            - Make the posibility of unlimited stop points in the movement (can make a trail if space impulse)
            - make the movement Smooth
            - get some animation to no gravity space
    */
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(playerTag)){
            playerGravity = other.gameObject.GetComponent<GravityManager>();
            ChangeGravity(other.gameObject.GetComponent<Rigidbody>());
            insideSpaceImpulse = true;
            TimeToQuit();
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag(playerTag)){
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag(playerTag)){
            playerGravity.ResetGravity();
            insideSpaceImpulse = false;    
        }
    }

    void EnablePlayerComponents(GameObject player, bool enable = true){

    }

    void ChangeGravity(Rigidbody playerRb){
        playerRb.velocity = Vector3.zero;
        playerGravity.IsUsingSpecialGravity = true;
        playerGravity.GravityDirection = (transform.position - playerRb.position).normalized;
        playerGravity.GravityForce = gravityForce;
    }

    async void TimeToQuit(){
        await Task.Delay((int)timeToEnd*1000);
        if(insideSpaceImpulse){
            playerGravity.ResetGravity();
        }
        
    }
    
}
