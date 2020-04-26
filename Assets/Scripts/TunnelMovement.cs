using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelMovement : MonoBehaviour
{
    public float forwardSpeed = 50;

    private void Update()
    {
        MoveForward(forwardSpeed);
    }
    
    public void Rotate(float amount)
    {
        transform.Rotate(Vector3.forward * amount);
    }

    private void MoveForward(float amount)
    {
        transform.position -= amount * Time.deltaTime * Vector3.forward;
    }
}
