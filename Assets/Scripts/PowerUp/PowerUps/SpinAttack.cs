using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpinAttack : MonoBehaviour, IPressReleaseAction{
    bool spinActive;
    float spinTime;
    [SerializeField] Animator playerAnimator;
    [SerializeField] InputActionManager playerInput;
    [SerializeField] GameObject meshObject;
    [SerializeField] float spinSpeed = 50;
    [SerializeField] bool inSpin;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    void Spin(bool state){
        spinActive = state;
        playerAnimator.SetBool(Animations.SpinPose.ToString(), state);
        if(state) playerAnimator.Play(Animations.SpinPose.ToString(),0);
        StartCoroutine(Spin());
        //Debug.Log((int)Animations.SpinPose);
    }

    IEnumerator Spin(){
        while(spinActive){
            meshObject.transform.Rotate(0f, spinSpeed * Time.fixedDeltaTime, 0, Space.Self);
            yield return null;
        }
    }

    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => Spin(true);

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext) => Spin(false);

    void OnEnable() {
        playerInput.OnWestButtonPerformed += OnButtonPressed;
        playerInput.OnWestButtonCanceled += OnButtonReleased;
    }
    void OnDisable() {
        playerInput.OnWestButtonPerformed -= OnButtonPressed;
        playerInput.OnWestButtonCanceled -= OnButtonReleased;
    }

}
