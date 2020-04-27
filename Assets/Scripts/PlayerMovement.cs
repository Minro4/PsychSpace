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

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * minSpeed;
    }

    private void FixedUpdate()
    {
        Boost(acceleration * Time.fixedDeltaTime);
        if (rb.velocity.z < minSpeed)
        {
            var velocity = rb.velocity;
            velocity = new Vector3(velocity.x, velocity.y, minSpeed);
            rb.velocity = velocity;
        }
    }

    public void Rotate(float amount)
    {
        transform.RotateAround(centerRotation.position, Vector3.forward, amount);
    }

    public void Boost(float amount)
    {
        rb.velocity += amount * Vector3.forward;
    }

    public void Boost(float amount, float time) //Amount / sec
    {
        rb.AddForce(Vector3.forward * amount);
        StartCoroutine(BoostOverTime(amount, time));
    }

    private IEnumerator BoostOverTime(float amount, float time)
    {
        var timeLeft = time;
        while (timeLeft > 0)
        {
            rb.AddForce(amount * Time.fixedDeltaTime * Vector3.forward);
            yield return new WaitForFixedUpdate();
            timeLeft -= Time.fixedDeltaTime;
        }
    }
}