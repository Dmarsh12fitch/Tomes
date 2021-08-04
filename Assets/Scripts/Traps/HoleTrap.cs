using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrap : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Offpos;
    public GameObject Onpos;
    public float pos ;
    private float spikeSpeed = 10;
    public bool Activated;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Activated == true ){
            StartCoroutine(SpikeOn());
        }
        //SpikeMovement();
       

       Debug.Log(pos);    
    }
        
        //Turns spike to on positon
        IEnumerator SpikeOn(){          
            Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, Onpos.transform.position, spikeSpeed );
            yield return new WaitForSeconds(2);
            StartCoroutine(SpikeOff());
            Activated = false;
            pos = 0;
        }
        //Turns spike to off position
        IEnumerator SpikeOff(){
            Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, Offpos.transform.position, spikeSpeed );
            yield return new WaitForSeconds(5);
            Activated = true;
            pos = 1;
        }

    //Checks and Sets spikes next positon
    private void SpikeMovement(){
        if (pos == 13 && Activated == true){
            StartCoroutine(SpikeOn());
            
        }
       // if (pos == 2 && Activated == true){
            //StartCoroutine(SpikeOn());
            
    
        
    }
}
