using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

public class SpaceImpulse : MonoBehaviour{
    [SerializeField] GameObject target;
    [SerializeField] string playerTag;
    [SerializeField] float speedToTarget;
    [SerializeField] float speedToCenter;
    [SerializeField] float timeToEnableCollider;
    [SerializeField] bool applyForceAtEnd;
    [SerializeField] float forceAtEnd;
    GameObject player;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag(playerTag)){
            GetComponent<SphereCollider>().enabled = false;
            player = other.gameObject;
            EnableComponents(false);
            StartCoroutine(MoveTo(transform.position, speedToCenter));
            EnableButtonBehaviour(true);
        }
    }

    void EnableComponents(bool enable){
        player.GetComponent<GravityManager>().enabled = enable;
        player.GetComponent<MovementManager>().enabled = enable;
        player.GetComponent<Rigidbody>().isKinematic = !enable;
    }

    void QuitSpace(){
        EnableComponents(true);
        EnableButtonBehaviour(false);
        EnableSphereCollider();
        StopAllCoroutines();
    }
    
    async void EnableSphereCollider(){
        await Task.Delay((int)(timeToEnableCollider*1000));
        GetComponent<SphereCollider>().enabled = true;
    }

    void LaunchPlayer(){
        StopAllCoroutines();
        StartCoroutine(MoveTo(target.transform.position, speedToTarget, true, applyForceAtEnd));
        EnableButtonBehaviour(false);
    }

    IEnumerator MoveTo(Vector3 position, float speed, bool activeComponetsAtEnd = false, bool applyForceAtEnd = false){
        float actualTime = 0;
        var playerRb = player.GetComponent<Rigidbody>();
        Vector3 iniPoint = player.transform.position;
        while (actualTime < 1){
            playerRb.MovePosition(Vector3.Lerp(iniPoint, position, actualTime));
            actualTime += speed * Time.deltaTime;
            yield return null;
        }

        playerRb.velocity = Vector3.zero;

        if(activeComponetsAtEnd){
            EnableComponents(true);
            EnableSphereCollider();
        }
        
        if(applyForceAtEnd){
            Vector3 direction = (target.transform.position - transform.position).normalized;
            playerRb.AddForce(direction * forceAtEnd, ForceMode.Impulse);
        }
    }

    void EnableButtonBehaviour(bool enable){
        var playerInput = player.GetComponent<InputActionManager>();
        if(enable){
            playerInput.OnEastPrimaryButtonPerformed += OnButtonPressed;
            playerInput.OnSouthPrimaryButtonPerformed += OnButtonReleased;
        }else{
            playerInput.OnEastPrimaryButtonPerformed -= OnButtonPressed;
            playerInput.OnSouthPrimaryButtonPerformed -= OnButtonReleased;
        }
    }

    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => QuitSpace();

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext) => LaunchPlayer();
}
