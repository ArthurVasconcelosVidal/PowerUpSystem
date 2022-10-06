using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class MainAttack : MonoBehaviour{
    [SerializeField] protected AnimationManager AnimationManager { get => PlayerManager.instance.AnimationManager; }
    [SerializeField] protected InputActionManager InputActionManager { get => PlayerManager.instance.InputActionManager; }
    [SerializeField] protected AttackManager AttackManager {get => PlayerManager.instance.AttackManager; }

    public abstract void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext);

    public virtual void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext){

    }

    void OnEnable() {
        InputActionManager.OnWestButtonPerformed += OnButtonPressed;
        InputActionManager.OnWestButtonCanceled += OnButtonReleased;
    }
    void OnDisable() {
        InputActionManager.OnWestButtonPerformed -= OnButtonPressed;
        InputActionManager.OnWestButtonCanceled -= OnButtonReleased;
    }
}
