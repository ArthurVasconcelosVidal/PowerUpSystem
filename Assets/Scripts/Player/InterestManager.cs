using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructures.ViliWonka.KDTree;

public class InterestManager : MonoBehaviour{
    [SerializeField] List<GameObject> interestObjects = new List<GameObject>();
    KDTree interestObjectsTree;
    [SerializeField] List<int> closestIndex;
    int nextAddPosition;

    void Awake() {
        Vector3[] objectPoints = GetPointFromObjects(interestObjects);
        BuildKDTree(objectPoints);
    }

    void FixedUpdate() {
        AttTreePositions();
        closestIndex = QueryClosestInTree();
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag(Tags.InterestObject.ToString()))
            IOInterestObject(true, other.gameObject);
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
        
        Vector3[] objectPoints = GetPointFromObjects(interestObjects);
        ReSizeTree(objectPoints);
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
        if(interestObjectsTree.Count > 0){
            for (int i = 0; i < interestObjectsTree.Count; i++){
                interestObjectsTree.Points[i] = interestObjects[i].transform.position;
            }
            interestObjectsTree.Rebuild();
        }
    }

    List<int> QueryClosestInTree(){
        List<int> results = new List<int>();
        KDQuery query = new KDQuery();
        Vector3 playerPosition = transform.position;
        query.ClosestPoint(interestObjectsTree, playerPosition, results);
        return results;
    }
}
