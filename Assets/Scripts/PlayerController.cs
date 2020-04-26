using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovement))]
public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed = 300f;
    private IMovement movement;

    private void Awake()
    {
        movement = GetComponent<IMovement>();
    }

    // Update is called once per frame

    private void Update()
    {
        var h =  horizontalSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        movement.Rotate(h);
    }
}