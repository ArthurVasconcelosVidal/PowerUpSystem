using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class MainAttack : MonoBehaviour{
    [SerializeField] protected AnimationManager animationManager;
    [SerializeField] protected InputActionManager playerInput;
    [SerializeField] protected AttackManager attackManager;

    public abstract void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext);

    public virtual void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext){

    }

    void OnEnable() {
        playerInput.OnWestButtonPerformed += OnButtonPressed;
        playerInput.OnWestButtonCanceled += OnButtonReleased;
    }
    void OnDisable() {
        playerInput.OnWestButtonPerformed -= OnButtonPressed;
        playerInput.OnWestButtonCanceled -= OnButtonReleased;
    }
}
