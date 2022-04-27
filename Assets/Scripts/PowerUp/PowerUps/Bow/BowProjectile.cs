using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StructLibrary;
public class BowProjectile : MonoBehaviour{
    Rigidbody rigidbody;
    public Vector3 ArrowDirection { get; set;}
    MinMaxFloat arrowTimeToDecay = new MinMaxFloat(0,4);
    float arrowIntensity;
    [SerializeField] float dragForce;
    float ShootForce { get; set;}
    bool init = false;
    [SerializeField] Vector4 teste = Vector4.one;
    Vector3[] arrowBezierPositions = new Vector3[10];

    public void Initialize(Vector3 arrowDirection, MinMaxFloat MinMaxForce, float shootForce){
        ArrowDirection = arrowDirection;
        ShootForce = shootForce;

        arrowIntensity = Mathf.InverseLerp(MinMaxForce.Min, MinMaxForce.Max, shootForce);

        rigidbody = GetComponent<Rigidbody>();
        GetAllBezierPositions();

        StartCoroutine("ArrowMovement");
    }

    void GetAllBezierPositions(){
        float time = 0;

        Vector3 firstPoint = transform.position;
        Vector3 secondPoint = transform.position + (transform.forward * 13);
        Vector3 thirdPoint = transform.position + (transform.forward * 13) - (transform.up * 3);

        for (int i = 0; i < arrowBezierPositions.Length; i++){
            arrowBezierPositions[i] = PositionAtQuadraticBezierCurve(time, firstPoint, secondPoint, thirdPoint);
            time += 0.1f;
        }
    }

    IEnumerator ArrowMovement(){
        for (int i = 0; i < arrowBezierPositions.Length - 1; i++){
            float progres = 0;
            const float SPEED = 2;
            while (transform.position != arrowBezierPositions[i + 1]){
                progres += SPEED * Time.fixedDeltaTime;
                progres = Mathf.Clamp01(progres);
                ArrowRotation(arrowBezierPositions[i+1] - transform.position);
                transform.position = Vector3.Lerp(arrowBezierPositions[i], arrowBezierPositions[i+1], progres);
                yield return null;
            }
            
        }
        Debug.Log("terminou");
        yield return null;
    }
    void ArrowRotation(Vector3 direction){
        direction = direction.normalized;
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
