using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using System.Threading.Tasks;
public class LookToTarget : MonoBehaviour{
    InterestManager InterestManager { get => PlayerManager.instance.InterestManager; }
    GameObject MeshObject { get => PlayerManager.instance.MeshObject; }
    [SerializeField] GameObject headAimObject;
    [SerializeField] GameObject baseLookPosition;
    [SerializeField] float speed;
    [SerializeField][Range(-1,1)] float lookAngleThreshHold = 0; 
    bool rightAngle;
    bool isLooking = false;
    bool isMovingToPoint = false;
    bool isMovingToOrigin = false;
    
    void OnClosestObjectBehavior(object sender, EventArgs args) => StartLookAt();

    void StartLookAt(){
        if(!isLooking)
            LookingUpdate();
    }

    async void LookingUpdate(){
        bool inOriginPoint = true;

        do {
            if(InterestManager.ClosestObject){
                isLooking = true;
                rightAngle = LookInRightAngle();
                inOriginPoint = headAimObject.transform.position == baseLookPosition.transform.position; 
                if(!isMovingToPoint && rightAngle) MoveToPoint();
                else if(!isMovingToPoint && !rightAngle && !inOriginPoint) MoveToOrigin();  
            }
            else 
                isLooking = false;

            await Task.Yield();
        } while(isLooking);
        
        if(!inOriginPoint && !isMovingToOrigin)
            MoveToOrigin();
    }

    bool LookInRightAngle(){
        var direction = InterestManager.ClosestObject.transform.position - MeshObject.transform.position;
        float angle = Vector3.Dot(direction.normalized, MeshObject.transform.forward);
        if (angle > lookAngleThreshHold)
            return true;
        else
            return false;
    }

    async void MoveToPoint(){
        isMovingToPoint = true;
        while (InterestManager.ClosestObject && isLooking && rightAngle){
            var direction = InterestManager.ClosestObject.transform.position - headAimObject.transform.position;
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
        InterestManager.OnClosestObject += OnClosestObjectBehavior;
    }

    void OnDisable() {
        InterestManager.OnClosestObject -= OnClosestObjectBehavior;
    }
 
}
