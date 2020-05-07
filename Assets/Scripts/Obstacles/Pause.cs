using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Pause : IObstacle
{
    private GameObject boostPrefab;
    private int pauseStartBoosts;
    private float openAngle;
    private float spacing;
    private Transform parent;
    private float length;

    public Pause(GameObject boostPrefab, int pauseStartBoosts, float openAngle, float spacing, float length,Transform parent)
    {
        this.boostPrefab = boostPrefab;
        this.pauseStartBoosts = pauseStartBoosts;
        this.openAngle = openAngle;
        this.spacing = spacing;
        this.parent = parent;
        this.length = length;
    }

    public ObstacleInfo Instantiate(float difficulty, ObstacleInfo info)
    {
        for (int i = 0; i < pauseStartBoosts; i++)
        {
            float objectZPos = info.zPos + i * spacing;
            InstantiatePrefab(info.angle, objectZPos);
        }

        return new ObstacleInfo(info.zPos + length, info.angle);
    }

    private GameObject InstantiatePrefab(float angle, float zPos)
    {
        return Object.Instantiate(boostPrefab, Vector3.forward * zPos, Quaternion.Euler(0, 0, angle), parent);
    }
}