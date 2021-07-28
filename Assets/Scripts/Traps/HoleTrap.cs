using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrap : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Offpos;
    public GameObject Onpos;
    public float pos = 0;
    private float spikeSpeed = 10;
    public bool Activated;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Activated == true && pos == 0){
            StartCoroutine(SpikeOn());
        }
        SpikeMovement();

       //Debug.Log(pos);    
    }
        
        //Turns spike to on positon
        IEnumerator SpikeOn(){          
            Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, Onpos.transform.position, spikeSpeed );
            yield return new WaitForSeconds(2);
            pos = 1;
        }
        //Turns spike to off position
        IEnumerator SpikeOff(){
            Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, Offpos.transform.position, spikeSpeed );
            yield return new WaitForSeconds(3);
            pos = 0;
        }

    //Checks and Sets spikes next positon
    private void SpikeMovement(){
        if (pos == 1 && Activated == true){
            StartCoroutine(SpikeOff());
            
        }
       // if (pos == 2 && Activated == true){
            //StartCoroutine(SpikeOn());
            
        
    }
}
