using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPlatform : MonoBehaviour
{
    public GameObject platform;
    public GameObject OnPos;
    public GameObject OffPos;

    public bool Activated;

    private float speed = 10.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          // Platforms speed 
        float platformSpeed = speed * Time.deltaTime;
       
       
        // Toggles the platform from On/Off 
        if (Activated == true){
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, OnPos.transform.position, platformSpeed );
        } else {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, OffPos.transform.position, platformSpeed );
        }
        

    }

    void PlatformToggle (){
       

    }
}
