using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour, IPressReleaseAction{

    [SerializeField] CinemachineFreeLook freeLookCM;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float camSpeedY = 1; //Default
    [SerializeField] float camSpeedX = 80; //Default
    bool canSwitchCamera = false;

    InputActionManager InputActionManager { get {return PlayerManager.instance.InputActionManager; } }

    void FixedUpdate(){
        if(freeLookCM.enabled) CameraMovement();
    }

    void CameraMovement(){
        if(PlayerManager.instance.InputActionManager.RightStickValue != Vector2.zero){
            freeLookCM.m_XAxis.Value += InputActionManager.RightStickValue.x * camSpeedX * Time.fixedDeltaTime;
            freeLookCM.m_YAxis.Value += InputActionManager.RightStickValue.y * camSpeedY * Time.fixedDeltaTime;
        }
    }

    void SwtichCamera(bool state){
        if(canSwitchCamera){
            freeLookCM.gameObject.SetActive(state);
            virtualCamera.gameObject.SetActive(!state);
        }

    }
    
    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => SwtichCamera(false);

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext) => SwtichCamera(true);

    void OnEnable() {
        //InputActionManager.OnRightTriggerButtonPerformed += OnButtonPressed;
        //InputActionManager.OnRightTriggerButtonCanceled += OnButtonReleased;  
    }

    void OnDisable() {
        //InputActionManager.OnRightTriggerButtonPerformed -= OnButtonPressed;
        //InputActionManager.OnRightTriggerButtonCanceled -= OnButtonReleased; 
    }

}
