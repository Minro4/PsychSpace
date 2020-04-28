using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{
    public Transform centerRotation;
    public float acceleration;
    public float minSpeed;
    private Rigidbody rb;

    private const float AccelerationDamping = 40;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * minSpeed;
    }

    private void FixedUpdate()
    {
        Accelerate();
        if (rb.velocity.z < minSpeed)
        {
            var velocity = rb.velocity;
            velocity = new Vector3(velocity.x, velocity.y, minSpeed);
            rb.velocity = velocity;
        }
    }


    private void Accelerate()
    {
        var speed = rb.velocity.z;
        var acc = acceleration / (speed + AccelerationDamping);
        Boost(acceleration * Time.fixedDeltaTime);
    }

    public void Rotate(float amount)
    {
        transform.RotateAround(centerRotation.position, Vector3.forward, amount);
    }

    public void Boost(float amount)
    {
        rb.velocity += amount * Vector3.forward;
    }

    public void Boost(float amount, float time)
    {
        StartCoroutine(BoostOverTime(amount, time));
    }

    private IEnumerator BoostOverTime(float amount, float time)
    {
        var timeLeft = time;
        var amountPerSec = amount / time;
        while (timeLeft > 0)
        {
            rb.velocity += amountPerSec * Time.fixedDeltaTime * Vector3.forward;
            yield return new WaitForFixedUpdate();
            timeLeft -= Time.fixedDeltaTime;
        }
    }

    public void TempBoost(float amount, float time)
    {
        StartCoroutine(TempBoostCoroutine(amount, time));
    }
    
    private IEnumerator TempBoostCoroutine(float amount, float time)
    {
        Boost(amount);
        yield return new WaitForSeconds(time);
        Boost(-amount);
    }
}