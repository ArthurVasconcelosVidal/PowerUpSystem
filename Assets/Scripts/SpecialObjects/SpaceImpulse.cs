using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

public class SpaceImpulse : MonoBehaviour{

    PlayerManager PlayerManager { get => PlayerManager.instance; }

    [SerializeField] GameObject target;
    [SerializeField] string playerTag;
    [SerializeField] float speedToTarget;
    [SerializeField] float speedToCenter;
    [SerializeField] float rotationSpeed;
    [SerializeField] float timeToEnableCollider;
    [SerializeField] float forceAtEnd;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag(playerTag)){
            EnableSphereCollider(false);
            EnableComponents(false);
            StartCoroutine(MoveTo(transform.position, speedToCenter));
            EnableButtonBehaviour(true);
            RotateTo();
            ToFlyAnimation();
        }
    }

    void QuitSpace(){
        EnableComponents(true);
        EnableButtonBehaviour(false);
        EnableSphereCollider(true);
        StopAllCoroutines();
        ToRollAnimation();
    }

    void LaunchPlayer(){
        StopAllCoroutines();
        StartCoroutine(MoveTo(target.transform.position, speedToTarget, true));
        EnableButtonBehaviour(false);
    }

    IEnumerator MoveTo(Vector3 position, float speed, bool activeComponetsAtEnd = false, bool applyForceAtEnd = false){
        float actualTime = 0;
        Vector3 iniPoint = PlayerManager.transform.position;
        Rigidbody playerRb = PlayerManager.CharacterRigidbody;
        while (actualTime < 1){
            playerRb.MovePosition(Vector3.Lerp(iniPoint, position, actualTime));
            actualTime += speed * Time.deltaTime;
            yield return null;
        }

        playerRb.velocity = Vector3.zero;
        
        if(activeComponetsAtEnd) ActiveComponents(); 
        ApplyForce(playerRb);
    }
    
    async void RotateTo(){
        float actualTime = 0;
        GameObject meshObject = PlayerManager.MeshObject;
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
        EnableSphereCollider(true);
        ToRollAnimation();
    }

    void ApplyForce(Rigidbody playerRb){
        if(forceAtEnd > 0){
            Vector3 direction = (target.transform.position - transform.position).normalized;
            playerRb.AddForce(direction * forceAtEnd, ForceMode.Impulse);
        }
        
    }

    void EnableButtonBehaviour(bool enable){
        var playerInput = PlayerManager.InputActionManager;
        if(enable){
            playerInput.OnEastPrimaryButtonPerformed += OnButtonPressed;
            playerInput.OnSouthPrimaryButtonPerformed += OnButtonReleased;
        }else{
            playerInput.OnEastPrimaryButtonPerformed -= OnButtonPressed;
            playerInput.OnSouthPrimaryButtonPerformed -= OnButtonReleased;
        }
    }

    void EnableComponents(bool enable){
        PlayerManager.GravityManager.enabled = enable;
        PlayerManager.CanUseMovement = enable;
        PlayerManager.CharacterRigidbody.isKinematic = !enable;
        PlayerManager.CanUseLookToTarget = enable;
        PlayerManager.CanUseActions = enable;
    }

    async void EnableSphereCollider(bool enable){
        await Task.Delay((int)(timeToEnableCollider*1000));
        GetComponent<SphereCollider>().enabled = enable;
    }

    void ToFlyAnimation() => PlayerManager.AnimationManager.PlayAnimation(Animations.FlyPose, 0.3f);
    void ToRollAnimation() => PlayerManager.AnimationManager.ForceAnimationPlay(Animations.DoubleJumpFlip);
    
    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => QuitSpace();
    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext) => LaunchPlayer();
}
