using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacle
{
    /// <returns>
    /// int -> Length
    /// float -> End angle
    /// </returns>
    Tuple<float,float> Instantiate(float difficulty, float zPos,float angle , float length);
}
