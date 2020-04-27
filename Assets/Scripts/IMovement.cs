using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    void Rotate(float amount);

    void Boost(float amount);

    void Boost(float amount, float time); //Amount / sec
}