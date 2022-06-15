using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour{
    [SerializeField] CinemachineFreeLook freeLookCM;
    [SerializeField] float camSpeedY = 1; //Default
    [SerializeField] float camSpeedX = 80; //Default

    PlayerManager PlayerManager { get {return PlayerManager.instance; } }

    void FixedUpdate(){
        CameraMovement();
    }

    void CameraMovement(){
        if(PlayerManager.instance.InputActionManager.RightStickValue != Vector2.zero){
            freeLookCM.m_XAxis.Value += PlayerManager.InputActionManager.RightStickValue.x * camSpeedX * Time.fixedDeltaTime;
            freeLookCM.m_YAxis.Value += PlayerManager.InputActionManager.RightStickValue.y * camSpeedY * Time.fixedDeltaTime;
        }
    }
}
