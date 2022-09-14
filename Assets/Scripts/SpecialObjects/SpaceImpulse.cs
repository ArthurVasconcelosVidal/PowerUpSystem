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
    [SerializeField] float rotationSpeed;
    [SerializeField] float timeToEnableCollider;
    [SerializeField] bool applyForceAtEnd;
    [SerializeField] float forceAtEnd;
    [SerializeField] GameObject player;
    [SerializeField] GameObject meshObject;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag(playerTag)){
            GetComponent<SphereCollider>().enabled = false;
            EnableComponents(false);
            StartCoroutine(MoveTo(transform.position, speedToCenter));
            EnableButtonBehaviour(true);
            var animator = player.GetComponent<Animator>();
            RotateTo();
            ToFlyAnimation();
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
        ToRollAnimation();
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
        
        if(activeComponetsAtEnd) ActiveComponents();
        if(applyForceAtEnd) ApplyForce(playerRb);
    }
    
    async void RotateTo(){
        float actualTime = 0;
        var playerRb = player.GetComponent<Rigidbody>();
        Quaternion iniRotation = meshObject.transform.rotation;
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion rotateToDirection = Quaternion.LookRotation(direction, meshObject.transform.up);
        while (actualTime < 1){
            meshObject.transform.rotation = Quaternion.Lerp(iniRotation, rotateToDirection, actualTime);
            actualTime += rotationSpeed * Time.deltaTime;
            await Task.Yield();
        }
    }

    void ActiveComponents(){
        EnableComponents(true);
        EnableSphereCollider();
        ToRollAnimation();
    }

    void ApplyForce(Rigidbody playerRb){
        Vector3 direction = (target.transform.position - transform.position).normalized;
        playerRb.AddForce(direction * forceAtEnd, ForceMode.Impulse);
    }

    void ToFlyAnimation(){
        var animationManager = player.GetComponent<AnimationManager>();
        animationManager.PlayAnimation(Animations.FlyPose, 0.3f);
    }
    void ToRollAnimation() {
        var animator = player.GetComponent<Animator>();
        animator.Play(Animations.DoubleJumpFlip.ToString(), 0);
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
