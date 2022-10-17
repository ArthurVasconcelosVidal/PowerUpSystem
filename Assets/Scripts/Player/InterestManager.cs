using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructures.ViliWonka.KDTree;
using System.Threading.Tasks;

public class InterestManager : MonoBehaviour{
    [SerializeField] List<GameObject> interestObjects = new List<GameObject>();
    [SerializeField] List<int> closestIndexList;
    KDTree interestObjectsTree;
    [SerializeField] GameObject Aim;
    [SerializeField] GameObject closestObject;
    GameObject ClosestObject {
        get{
            if (interestObjects.Count == 1){
                return interestObjects[0];
            }else if(interestObjects.Count == 0){
                return null;
            }else{
                return closestObject;
            }
        }

        set => closestObject = value;
    }

    //Debug
    private void Update() {
        if(ClosestObject){
            Aim.transform.position = ClosestObject.transform.position;
        }
    }

    void Awake() {
        Vector3[] objectPoints = GetPointFromObjects(interestObjects);
        BuildKDTree(objectPoints);
    }

    async void VerifyClosestObject(){
        const float SECONDS = 0.5f;
        await Task.Delay((int)(SECONDS * 1000));
        
        if(interestObjectsTree.Count > 1){
            AttTreePositions();
            closestIndexList = QueryClosestInTree();
            ClosestObject = interestObjects[closestIndexList[0]];
            VerifyClosestObject(); 
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag(Tags.InterestObject.ToString())){
            IOInterestObject(true, other.gameObject);
            VerifyClosestObject(); //Start verify Trigger
        }   
    }

    void OnTriggerExit(Collider other) {
        if(other.CompareTag(Tags.InterestObject.ToString()))
            IOInterestObject(false, other.gameObject);
    }

    void IOInterestObject(bool iO, GameObject gameObject ){
        if (iO)
            interestObjects.Add(gameObject);
        else
            interestObjects.Remove(gameObject);
        
        if(interestObjects.Count > 1 ){
            Vector3[] objectPoints = GetPointFromObjects(interestObjects);
            ReSizeTree(objectPoints);
        }
    }

    Vector3[] GetPointFromObjects(List<GameObject> objects){
        Vector3[] objectPoints = new Vector3[objects.Count];
        for (int i = 0; i < objects.Count; i++){
            objectPoints[i] = objects[i].transform.position;
        }
        return objectPoints;
    }

    void BuildKDTree(Vector3[] points){
        int maxPointsPerLeafNode = 32; 
        interestObjectsTree = new KDTree(points, maxPointsPerLeafNode);
    }

    void ReSizeTree(Vector3[] newPoints){
        const int MAX_POINTS_PER_LEAF_NODE = 32;
        interestObjectsTree.Build(newPoints, MAX_POINTS_PER_LEAF_NODE);
    }

    void AttTreePositions(){
        //fix a index out of range
        for (int i = 0; i < interestObjectsTree.Count; i++){
            interestObjectsTree.Points[i] = interestObjects[i].transform.position;
        }
        interestObjectsTree.Rebuild();
    }

    List<int> QueryClosestInTree(){
        List<int> results = new List<int>();
        KDQuery query = new KDQuery();
        Vector3 playerPosition = transform.position;
        query.ClosestPoint(interestObjectsTree, playerPosition, results);
        return results;
    }
}
