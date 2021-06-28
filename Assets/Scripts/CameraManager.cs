using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
   [SerializeField] private Camera camera1;
   [SerializeField] private Camera camera2;
    // Start is called before the first frame update
    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Inverts the enabled property on each camera. e.g if camera1 is enabled it disables it and vice versa 
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }
    }
}
