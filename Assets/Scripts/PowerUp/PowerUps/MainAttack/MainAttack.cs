using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class MainAttack : MonoBehaviour{
    [SerializeField] protected PlayerManager PlayerManager { get => PlayerManager.instance; }
    [SerializeField] protected AnimationManager AnimationManager { get => PlayerManager.instance.AnimationManager; }
    [SerializeField] protected InputActionManager InputActionManager { get => PlayerManager.instance.InputActionManager; }
    [SerializeField] protected AttackManager AttackManager {get => PlayerManager.instance.AttackManager; }

    public virtual void FirstAction(object sender, InputAction.CallbackContext buttonContext){
        if(!PlayerManager.CanUseActions)
            return;

        OnButtonPressed(buttonContext);
    }

    public virtual void SecondAction(object sender, InputAction.CallbackContext buttonContext){
        if(!PlayerManager.CanUseActions)
            return;
        
        OnButtonReleased(buttonContext);
    }

    public abstract void OnButtonPressed(InputAction.CallbackContext buttonContext);

    public virtual void OnButtonReleased(InputAction.CallbackContext buttonContext){}

    void OnEnable() {
        InputActionManager.OnWestButtonPerformed += FirstAction;
        InputActionManager.OnWestButtonCanceled += SecondAction;
    }
    void OnDisable() {
        InputActionManager.OnWestButtonPerformed -= FirstAction;
        InputActionManager.OnWestButtonCanceled -= SecondAction;
    }
}
