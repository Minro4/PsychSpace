using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{
    
    public void Rotate(float amount)
    {
        transform.Rotate(Vector3.forward * amount);
    }
}