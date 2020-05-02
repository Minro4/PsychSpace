using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpingManager : MonoBehaviour
{
    public int centerFavoritism = 2;
    public float range;
    public float baseTime = 100;
    public Rigidbody player;
    public Material[] warpingMats;


    private Vector2 lastTarget = Vector2.zero;
    private bool goingToTargetFlag = false;
    private static readonly int Vector3WarpCenter = Shader.PropertyToID("Vector3_WarpCenter");

    // Update is called once per frame
    void Update()
    {
        if (!goingToTargetFlag)
        {
            StartCoroutine(GoToTarget(Target()));
        }
    }


    IEnumerator GoToTarget(Vector2 newTarget)
    {
        goingToTargetFlag = true;
        //var dist = Vector2.Distance(lastTarget, newTarget);

        float time = 0;
        while (time < baseTime)
        {
            float perc = time / baseTime;
            float smoothedPerc = Mathf.SmoothStep(0, 1, perc);
            Vector2 newPos = Vector2.Lerp(lastTarget, newTarget, smoothedPerc);
            UpdateMats(newPos);
            yield return null;
            time += (Time.deltaTime * player.velocity.z);
        }

        lastTarget = newTarget;
        goingToTargetFlag = false;
    }

    private Vector2 Target()
    {
        Vector2 nextTarget = Vector2.zero;
        for (int i = 0; i < centerFavoritism; i++)
        {
            nextTarget += Random.insideUnitCircle;
        }

        return nextTarget * range / centerFavoritism;
    }

    private void UpdateMats(Vector3 newPos)
    {
        foreach (var mat in warpingMats)
        {
            mat.SetVector(Vector3WarpCenter, newPos);
        }
    }
}