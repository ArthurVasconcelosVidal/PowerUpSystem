using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour{
    [SerializeField] CinemachineFreeLook freeLookCM;
    [SerializeField] float camSpeedY = 1; //Default
    [SerializeField] float camSpeedX = 80; //Default

    void FixedUpdate(){
        CameraMovement();
    }

    void CameraMovement(){
        if(PlayerManager.instance.InputManager.RightStickValue != Vector2.zero){
            freeLookCM.m_XAxis.Value += PlayerManager.instance.InputManager.RightStickValue.x * camSpeedX * Time.fixedDeltaTime;
            freeLookCM.m_YAxis.Value += PlayerManager.instance.InputManager.RightStickValue.y * camSpeedY * Time.fixedDeltaTime;
        }
    }
}
