using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using System.Threading.Tasks;
public class LookToTarget : MonoBehaviour{
    [SerializeField] InterestManager interestManager;
    [SerializeField] MultiAimConstraint headAim;
    [SerializeField] GameObject headAimObject;
    [SerializeField] float speed;

    void OnClosestObjectBehavior(object sender, GameObject closestObject) => StartLookAt(closestObject);

    void StartLookAt(GameObject closestGameObject){
        
    }
/*
    IEnumerator MoveAimToPoint(GameObject targetObj){
        while (true){
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time);
        }
    }

    async void MoveAimToPoint(GameObject targetObj){
        float percent = 0;
        Vector3 startPosition = headAimObject.transform.position;
        
        while (percent < 1){
            percent += Time.fixedDeltaTime * speed;
            headAimObject.transform.position = Vector3.Lerp(startPosition, targetObj.transform.position, percent);
            await Task.Yield();
        }

        //MoveWhileClosestObjectExist(headAimObject);
    }
/*
    async void MoveWhileClosestObjectExist(GameObject objToMove){
        while (interestManager.ClosestObject){
            objToMove.transform.position = interestManager.ClosestObject.transform.position;
            await Task.Yield();
        }
    }
*/
    void OnEnable() {
        interestManager.OnClosestObjectActive += OnClosestObjectBehavior;
    }

    void OnDisable() {
        interestManager.OnClosestObjectActive -= OnClosestObjectBehavior;
    }
 
}
