using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovControl : MonoBehaviour
{
    public float fovMult;
    public float minFov;
    public float maxFov;
    public Rigidbody ship;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var speed = ship.velocity.z;
        var newFov = Mathf.Min(minFov + speed * fovMult, maxFov);
        cam.fieldOfView = newFov;
    }
}