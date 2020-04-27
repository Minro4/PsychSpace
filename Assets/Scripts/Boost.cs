using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float boostAmount;
    public float speedPercAmount;

    public bool boostOverTime = false;
    public float time;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var acc = other.GetComponent<IMovement>();
        if (acc == null)
            throw new Exception("Player Object without Movement");

        var boost = boostAmount + other.GetComponent<Rigidbody>().velocity.z * speedPercAmount;
        
        if (boostOverTime)
            acc.Boost(boost, time);
        else
            acc.Boost(boost);
    }
}