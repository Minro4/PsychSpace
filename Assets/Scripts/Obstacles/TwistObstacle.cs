using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class TwistObstacle : IObstacle
{
    private GameObject prefab;
    private float openAngle;
    private float spacing;
    private float length;
    
    private Transform parent;
    //public Range[] angles;

    public TwistObstacle(GameObject prefab, float openAngle, float spacing, float length, Transform parent)
    {
        this.prefab = prefab;
        this.openAngle = openAngle;
        this.spacing = spacing;
        this.parent = parent;
        this.parent = parent;
        this.length = length;
    }

    public ObstacleInfo Instantiate(float difficulty, ObstacleInfo info)
    {
        int nbrObs = (int) (length / spacing);
        var angleProg = (difficulty * (1 - Random.Range(0, 2) * 2)) / nbrObs;
        float endAngle = GenerateTwist(info.angle, angleProg, nbrObs, info.zPos);
        return new ObstacleInfo(info.zPos + nbrObs * spacing, endAngle);
    }

    private float GenerateTwist(float startAngle, float angleProg, int obsCount, float zPos)
    {
        for (int i = 0; i < obsCount; i++)
        {
            float angle = openAngle + startAngle + i * angleProg;
            float objectZPos = zPos + i * spacing;
            InstantiatePrefab(angle, objectZPos);
        }

        return openAngle + startAngle + obsCount * angleProg;
    }

    private GameObject InstantiatePrefab(float angle, float zPos)
    {
        return Object.Instantiate(prefab, Vector3.forward * zPos, Quaternion.Euler(0, 0, angle), parent);
    }
}