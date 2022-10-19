using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using System.Threading.Tasks;
public class LookToTarget : MonoBehaviour{
    [SerializeField] InterestManager interestManager;
    [SerializeField] MultiAimConstraint headAim;
    [SerializeField] GameObject headAimObject;
    [SerializeField] GameObject baseLookPosition;
    [SerializeField] bool isLooking = false;
    [SerializeField] float speed;

    void OnClosestObjectBehavior(object sender, EventArgs args) => StartLookAt();

    void StartLookAt(){
        if(!isLooking){
            isLooking = true;
            StopCoroutine(MoveBackToOrigin());
            MoveAimToPoint();
        }

    }

    async void MoveAimToPoint(){
        while (interestManager.ClosestObject){
            var direction = interestManager.ClosestObject.transform.position - headAimObject.transform.position;
            if(direction.sqrMagnitude > 0.05) headAimObject.transform.position += direction.normalized * speed * Time.fixedDeltaTime; 
            await Task.Yield();
        }
        isLooking = false;
        StartCoroutine(MoveBackToOrigin());
    }

    IEnumerator MoveBackToOrigin(){
        float percent = 0;
        Vector3 startPosition = headAimObject.transform.position;
        while (percent < 1){
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
