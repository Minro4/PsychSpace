using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    public float distance; //BPM

    public int obsForwardCount = 10;

    public GameObject[] obsPrefabs;
    public GameObject boostPrefab;

    private IObstacle[] obstacles;

    // Start is called before the first frame update
    private void Awake()
    {
        obstacles = new IObstacle[]
        {
            new Pause(boostPrefab, 1, 0, distance, 200, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 300, transform),
            new Pause(boostPrefab, 1, 0, distance, 100, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new Pause(boostPrefab, 2, 0, distance, 300, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new Pause(boostPrefab, 2, 0, distance, 600, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new Pause(boostPrefab, 1, 0, distance, 200, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new Pause(boostPrefab, 2, 0, distance, 600, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new Pause(boostPrefab, 1, 0, distance, 300, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new Pause(boostPrefab, 1, 0, distance, 200, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 300, transform),
            new Pause(boostPrefab, 1, 0, distance, 100, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new Pause(boostPrefab, 2, 0, distance, 300, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new Pause(boostPrefab, 2, 0, distance, 600, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new Pause(boostPrefab, 1, 0, distance, 200, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new Pause(boostPrefab, 2, 0, distance, 600, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new Pause(boostPrefab, 1, 0, distance, 300, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
            new TwistObstacle(obsPrefabs[Random.Range(0, obsPrefabs.Length)], 0, 50, 250, transform),
        };


        GenerateMap();
    }

// Update is called once per frame
    private void GenerateMap() //unit/sec
    {
        ObstacleInfo lastObs = new ObstacleInfo(0, 0);
        for (int i = 0; i < obstacles.Length; i++)
        {
            lastObs = InstObs(lastObs, obstacles[i]); //Vector3.forward * i * distance);
        }
    }


    private ObstacleInfo InstObs(ObstacleInfo lastObs, IObstacle obstacle /*Vector3 position*/)
    {
        return obstacle.Instantiate(180, lastObs);

        /*   var pref = obsPrefabs[Random.Range(0, obsPrefabs.Length)];
           var rot = Quaternion.Euler(0, 0, Random.value * 360);
   
           var twist = new TwistObstacle(pref, 0, 50, transform);
           return twist.Instantiate(180, lastObs.zPos, lastObs.angle, 200);*/
    }
}