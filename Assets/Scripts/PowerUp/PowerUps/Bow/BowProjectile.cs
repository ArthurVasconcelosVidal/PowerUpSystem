using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StructLibrary;
public class BowProjectile : MonoBehaviour{
    Rigidbody rigidbody;
    float arrowIntensity;
    Vector3[] arrowBezierPositions = new Vector3[10];

    public void Initialize(Vector3 arrowDirection, MinMaxFloat MinMaxForce, float shootForce){
        arrowIntensity = Mathf.InverseLerp(MinMaxForce.Min, MinMaxForce.Max, shootForce);

        rigidbody = GetComponent<Rigidbody>();
        GetAllBezierPositions(arrowIntensity);

        StartCoroutine("ArrowMovementAndRotation ");
    }

    void GetAllBezierPositions(float arrowForce){
        float time = 0;
        arrowForce = Mathf.Clamp(arrowForce,.1f,1);
        const float MAX_LENGTH = 13;
        const float MIN_LENGTH = 3;

        Vector3 firstPoint = transform.position;
        Vector3 secondPoint = transform.position + (transform.forward * (MAX_LENGTH * arrowForce));
        Vector3 thirdPoint = transform.position + (transform.forward * (MAX_LENGTH * arrowForce)) - (transform.up * (MIN_LENGTH * arrowForce));

        for (int i = 0; i < arrowBezierPositions.Length; i++){
            arrowBezierPositions[i] = PositionAtQuadraticBezierCurve(time, firstPoint, secondPoint, thirdPoint);
            time += 0.1f;
        }
    }

    IEnumerator ArrowMovementAndRotation(){
        for (int i = 0; i < arrowBezierPositions.Length - 1; i++){
            while (Vector3.Distance(transform.position,arrowBezierPositions[i + 1]) > 0.1f){
                var direction = arrowBezierPositions[i+1] - transform.position;
                ArrowRotation(direction.normalized);
                MoveArrow(direction);
                yield return null;
            }
        }
        yield return null;
    }

    void MoveArrow(Vector3 direction){
        const float SPEED = 2;
        transform.position += direction.normalized * SPEED * Time.fixedDeltaTime;
    }

    void ArrowRotation(Vector3 direction){
        const float ROTATION_SPEED = 100;
        var newRotation = Quaternion.FromToRotation(transform.forward, direction) * transform.rotation;
        transform.rotation = Quaternion.Lerp(PlayerManager.instance.MeshObject.transform.rotation, newRotation, ROTATION_SPEED * Time.fixedDeltaTime);
    }

    Vector3 PositionAtQuadraticBezierCurve(float time, Vector3 p1, Vector3 p2, Vector3 p3) => (((1 - time) * (1 - time)) * p1) + (2 * (1 - time) * time * p2) + (time * time) * p3;

    void OnDrawGizmos() {
        Gizmos.color = new Color(.5f,0,1,0.5f);
        Gizmos.DrawSphere(arrowBezierPositions[0],0.2f);
        Gizmos.DrawSphere(arrowBezierPositions[1],0.2f);
        Gizmos.DrawSphere(arrowBezierPositions[2],0.2f);
        Gizmos.DrawSphere(arrowBezierPositions[3],0.2f);
        Gizmos.DrawSphere(arrowBezierPositions[4],0.2f);
        Gizmos.DrawSphere(arrowBezierPositions[5],0.2f);
        Gizmos.DrawSphere(arrowBezierPositions[6],0.2f);
        Gizmos.DrawSphere(arrowBezierPositions[8],0.2f);
        Gizmos.DrawSphere(arrowBezierPositions[9],0.2f);
    }
}
