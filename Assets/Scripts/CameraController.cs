using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Using SerializeField so that variables can be accessed in the inspector but remain private.
    //This is done purely for personal preference and has no effect on the overall code
    [SerializeField] private GameObject player;

    [SerializeField] private Vector3 offset;
    

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
