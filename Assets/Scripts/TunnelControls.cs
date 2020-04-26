using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelControls : MonoBehaviour
{
    public float horizontalSpeed = 1f;
    
    private TunnelMovement mov;
    private void Awake()
    {
        mov = GetComponent<TunnelMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
       /* var h = horizontalSpeed * Input.GetAxis("Mouse X");
        mov.Rotate(h);*/
       
       var h =  horizontalSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
       mov.Rotate(-h);
    }
}
