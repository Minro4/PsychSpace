using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacle
{

    ObstacleInfo Instantiate(float difficulty, ObstacleInfo info);
}
