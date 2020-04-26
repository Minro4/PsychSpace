using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public float tempo; //BPM

    public int obsForwardCount = 100;

    public GameObject[] obsPrefabs;

    // Start is called before the first frame update
    private void Awake()
    {
        var speed = GetComponent<TunnelMovement>().forwardSpeed;
        GenerateMap(speed);
    }

    // Update is called once per frame
    private void GenerateMap(float speed )//unit/sec
    {
        var waitTime = 60 / tempo;
        var dist = waitTime * speed;

        for (int i = 1; i <= obsForwardCount; i++)
        {
            InstObs(Vector3.forward * i * dist);
        }
        
    }


    private GameObject InstObs(Vector3 position)
    {
        var pref = obsPrefabs[Random.Range(0, obsPrefabs.Length)];
        var rot = Quaternion.Euler(0, 0, Random.value * 360);
        var obj = Instantiate(pref, position, rot,this.transform);

        return obj;
    }
}
