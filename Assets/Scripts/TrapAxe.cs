using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAxe : MonoBehaviour
{
    public bool axeToggle;

    public GameObject Axe;

    private float speed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (axeToggle == true) {
           Axe.transform.Rotate(Vector3.left * speed * Time.deltaTime);
       }
    }

  
}
