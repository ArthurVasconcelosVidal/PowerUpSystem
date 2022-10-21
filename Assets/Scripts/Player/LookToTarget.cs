using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using System.Threading.Tasks;
public class LookToTarget : MonoBehaviour{
    [SerializeField] InterestManager interestManager;
    [SerializeField] GameObject MeshObject {get => PlayerManager.instance.MeshObject;}
    [SerializeField] GameObject headAimObject;
    [SerializeField] GameObject baseLookPosition;
    bool rightAngle;
    [SerializeField] bool isLooking = false;
    [SerializeField] bool isMovingToPoint = false;
    [SerializeField] bool isMovingToOrigin = false;
    [SerializeField] float speed;
    
    void OnClosestObjectBehavior(object sender, EventArgs args) => StartLookAt();

    void StartLookAt(){
        if(!isLooking){
            isLooking = true;
            SetIsLooking();
            MoveToPoint();
        }
    }

    async void SetIsLooking(){
        const float SECONDS = 0.5f;
        await Task.Delay((int)(SECONDS * 1000));
        if(interestManager.ClosestObject) isLooking = true;
        else isLooking = false; 
        
        if(isLooking) {
            rightAngle = LookInRightAngle();
            SetIsLooking();
            if(!isMovingToPoint && rightAngle) MoveToPoint();
        }else if(headAimObject.transform.position != baseLookPosition.transform.position && !isMovingToOrigin){
            MoveToOrigin();
        }
    }

    bool LookInRightAngle(){
        var direction = interestManager.ClosestObject.transform.position - MeshObject.transform.position;
        float angle = Vector3.Dot(direction.normalized, MeshObject.transform.forward);
        if (angle > 0)
            return true;
        else
            return false;
    }

    async void MoveToPoint(){
        isMovingToPoint = true;
        while (interestManager.ClosestObject && isLooking && rightAngle){
            var direction = interestManager.ClosestObject.transform.position - headAimObject.transform.position;
            if(direction.sqrMagnitude > 0.05) headAimObject.transform.position += direction.normalized * speed * Time.fixedDeltaTime;
            await Task.Yield();
        }
        isMovingToPoint = false;
    }

    async void MoveToOrigin(){
        float percent = 0;
        Vector3 startPosition = headAimObject.transform.position;
        isMovingToOrigin = true;
        while (percent < 1 && (!isLooking || !rightAngle)){
            percent += Time.fixedDeltaTime * speed;
            headAimObject.transform.position = Vector3.Lerp(startPosition, baseLookPosition.transform.position, percent);
            await Task.Yield();
        }
        isMovingToOrigin = false;
    }

    void OnEnable() {
        interestManager.OnClosestObject += OnClosestObjectBehavior;
    }

    void OnDisable() {
        interestManager.OnClosestObject -= OnClosestObjectBehavior;
    }
 
}
