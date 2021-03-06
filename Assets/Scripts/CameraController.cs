using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Using SerializeField so that variables can be accessed in the inspector but remain private.
    //This is done purely for personal preference and has no effect on the overall code
    [SerializeField] private GameObject player;
    private Vector3 offset;
    // controls the sensitivity of the camera rotation
    [SerializeField] private float sensitivity;
    private Vector2 rotation;

     void Start()
     {
         // Sets the offset to the position the camera is placed in the scene  
         offset = transform.position - player.transform.position;
     }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.position = player.transform.position + offset;
        RotateCamera();
    }

    private void RotateCamera()
    {
        // Allows for rotating the camera on the y axis when you hold down left mouse 
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // Gets the mouse y axis input
            Vector2 input = new Vector2(0, Input.GetAxis("Mouse Y"));
            // sets the speed of the rotation with sensitivity. And also sets the vector
            rotation += input * (sensitivity * Time.deltaTime);
            // converts the rotation into a Euler Angle
            transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
        }
        

    }

    
}
