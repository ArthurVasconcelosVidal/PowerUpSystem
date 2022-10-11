using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class KDTree{
    KDNode[] treeNodes;
    void BuildTree(Vector3[] pointList){
        Array.Resize(ref treeNodes, pointList.Length);

    }

    Vector3[] GetRandomPoints(Vector3[] pointList){
        if (pointList.Length > 3){
            
            System.Random rnd = new System.Random();
            Vector3[] randomPoints = new Vector3[3];
            
            for (int i = 0; i < 2; i++){
                int randomPos = rnd.Next(0, pointList.Length -1);
                randomPoints[i] = pointList[randomPos];
            }

            return randomPoints;
        }else
            return pointList;
    }

    Vector3 ClosestToMedianPoint(Vector3[] points){
        Vector3 finalPoint = points[0];

        if(points.Length > 1){

            Vector3 midPoint = Vector3.zero;
            foreach (var point in points){
                midPoint.x += point.x;
                midPoint.y += point.y;
                midPoint.z += point.z;
            }

            midPoint.x = midPoint.x/points.Length;
            midPoint.y = midPoint.y/points.Length;
            midPoint.z = midPoint.z/points.Length;

            float distance = float.MaxValue;
            foreach (var point in points){
                float pointsDistance = Vector3.Distance(midPoint,point); 
                if(distance > pointsDistance){
                    finalPoint = point;
                    distance = pointsDistance;
                }
            }
        }
         
        return finalPoint;
    } 
}
