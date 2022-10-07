using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BoomerangProjectile : MonoBehaviour{
    
    [SerializeField] Rigidbody boomerangRB;
    [SerializeField] float speed;
    [SerializeField] GameObject meshObject;
    GameObject returnObj;
    Vector3 targetPnt;

    public void StartBoo(GameObject returnObj, Vector3 targetPnt){
        this.returnObj = returnObj;
        this.targetPnt = targetPnt;
        BoomerangBehavior(returnObj.transform.position, targetPnt);
    }

    async void BoomerangBehavior(Vector3 startPoint, Vector3 endPoint, bool canBooReturn = true){
        const float MAX_DISTANCE = 1;
        const float BEZIER_TIME_OFFSET = 0.1f;
        const float MID_POINT_OFFSET = 7;
        float actualPos = 0;
        
        while (actualPos < MAX_DISTANCE){
            if(!canBooReturn) endPoint = returnObj.transform.position;
            actualPos = InverseV3Lerp(startPoint, endPoint, transform.position);
            float nextStep = Mathf.Clamp01(actualPos + BEZIER_TIME_OFFSET);
            Vector3 midPoint = CalculateMidPoint(startPoint, endPoint, MID_POINT_OFFSET);
            Vector3 nextPos = PositionAtQuadraticBezierCurve(startPoint, midPoint, endPoint,nextStep);
            Vector3 direction = (nextPos - transform.position ).normalized;
            boomerangRB.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
            RotateBoo();
            await Task.Yield();
        }

        if(canBooReturn){
            BoomerangBehavior(endPoint, returnObj.transform.position, false);
        }else{
            DestroyItself();
        }
    }

    void RotateBoo(){
        const float ROTATE_SPEED = 500;
        meshObject.transform.Rotate(meshObject.transform.up * ROTATE_SPEED * Time.fixedDeltaTime);
    }

    void DestroyItself(){
        Destroy(this.gameObject);
    }

    Vector3 PositionAtQuadraticBezierCurve(Vector3 initPoint, Vector3 midPoint, Vector3 endPoint, float time) { 
        return (((1 - time) * (1 - time)) * initPoint) + (2 * (1 - time) * time * midPoint) + (time * time) * endPoint;
    }

    Vector3 CalculateMidPoint(Vector3 initPoint, Vector3 endPoint, float offset){
        Vector3 midPoint = Vector3.Lerp(initPoint, endPoint, 0.5f);
        Vector3 direction = initPoint - endPoint;
        Vector3 perpendicularDirection = Vector3.Cross(direction, transform.up).normalized;
        return midPoint + perpendicularDirection * offset;
    }

    float InverseV3Lerp(Vector3 a, Vector3 b, Vector3 value){
         Vector3 AB = b - a;
         Vector3 AV = value - a;
         return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);
    }
}
