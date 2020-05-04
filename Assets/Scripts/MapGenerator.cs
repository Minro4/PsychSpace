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

    // Start is called before the first frame update
    private void Awake()
    {
        GenerateMap();
    }

    // Update is called once per frame
    private void GenerateMap( )//unit/sec
    {
        Tuple<float, float> lastObs = new Tuple<float, float>(0,0);

        for (int i = 1; i <= obsForwardCount; i++)
        {
            lastObs = InstObs(lastObs); //Vector3.forward * i * distance);
        }
        
    }


    private  Tuple<float, float> InstObs(Tuple<float, float> lastObs/*Vector3 position*/)
    {
        var pref = obsPrefabs[Random.Range(0, obsPrefabs.Length)];
        var rot = Quaternion.Euler(0, 0, Random.value * 360);
      
        var twist = new TwistObstacle(pref,0,10,transform);
        return twist.Instantiate(180, lastObs.Item1, lastObs.Item2,50);
    }
}
