using System.Collections;
using System.Collections.Generic;
using CollabProxy.UI;
using UnityEngine;

public class PlayerAcceleration : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Boost(float amount)
    {
        rb.AddForce(Vector3.forward * amount);
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
            rb.AddForce(amount * Time.fixedTime * Vector3.forward);
            yield return new WaitForFixedUpdate();
            timeLeft -= Time.fixedTime;
        }
    }
}