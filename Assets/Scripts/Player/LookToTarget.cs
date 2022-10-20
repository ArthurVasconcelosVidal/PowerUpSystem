using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using System.Threading.Tasks;
public class LookToTarget : MonoBehaviour{
    [SerializeField] InterestManager interestManager;
    [SerializeField] GameObject MeshObject {get => PlayerManager.instance.MeshObject;}
    [SerializeField] MultiAimConstraint headAim;
    [SerializeField] GameObject headAimObject;
    [SerializeField] GameObject baseLookPosition;
    [SerializeField] bool isLooking = false;
    bool isReturningToNormal;
    [SerializeField] bool lookState = true;
    [SerializeField] float speed;

    //IEnumerator moveToPoint, moveToOrigin;

    void OnClosestObjectBehavior(object sender, EventArgs args) => StartLookAt();

    void Awake() {
       // moveToPoint = MoveToPoint();
        //moveToOrigin = MoveToOrigin();    
    }

    void StartLookAt(){
        if(!isLooking){
            isLooking = true;
            MoveAim();
        }
    }
    
    //Fix this
    async void MoveAim(){
        while (interestManager.ClosestObject){
            bool rightAngle = LookInRightAngle();
            IEnumerator moveToPoint = MoveToPoint();
            IEnumerator moveToOrigin = MoveToOrigin();   
            if(rightAngle && lookState){
                lookState = false;
                StopCoroutine(moveToOrigin);
                StartCoroutine(moveToPoint);
                print("Olhando pro ponto");
            }else if(!rightAngle && !lookState){
                lookState = true;
                StopCoroutine(moveToPoint);
                StartCoroutine(moveToOrigin);
                print("Olhando pra origem");
            }
            await Task.Yield();
        }
        StartCoroutine(MoveToOrigin());
        isLooking = false;
    }

    bool LookInRightAngle(){
        var direction = interestManager.ClosestObject.transform.position - MeshObject.transform.position;
        float angle = Vector3.Dot(direction.normalized, MeshObject.transform.forward);
        if (angle > 0)
            return true;
        else
            return false;
    }

    IEnumerator MoveToPoint(){
        while (interestManager.ClosestObject){
            var direction = interestManager.ClosestObject.transform.position - headAimObject.transform.position;
            if(direction.sqrMagnitude > 0.05) headAimObject.transform.position += direction.normalized * speed * Time.fixedDeltaTime;
            yield return null;
        }
    }

    IEnumerator MoveToOrigin(){
        float percent = 0;
        Vector3 startPosition = headAimObject.transform.position;
        while (percent < 1){
            Debug.Log("here");
            percent += Time.fixedDeltaTime * speed;
            headAimObject.transform.position = Vector3.Lerp(startPosition, baseLookPosition.transform.position, percent);
            yield return null;
        }
    }

    void OnEnable() {
        interestManager.OnClosestObject += OnClosestObjectBehavior;
    }

    void OnDisable() {
        interestManager.OnClosestObject -= OnClosestObjectBehavior;
    }
 
}
