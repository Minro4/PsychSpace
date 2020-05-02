using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float boostAmount;
    public float speedPercAmount;

    public float boostOverTimeAmount;
    public float speedPercOverTimeAmount;
    public float time;

    public float tempBoost;
    public float tempBoostTime;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var acc = other.GetComponent<IMovement>();
        if (acc == null)
            throw new Exception("Player Object without Movement");

        var instantBoost = boostAmount + other.GetComponent<Rigidbody>().velocity.z * speedPercAmount;
        var boostOverTime = boostOverTimeAmount + other.GetComponent<Rigidbody>().velocity.z * speedPercOverTimeAmount;
       // Debug.Log("Boost over time "+ boostOverTime);
        acc.Boost(instantBoost);
        acc.Boost(boostOverTime, time);
        acc.TempBoost(tempBoost,tempBoostTime);
        
        
    }
}