using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFloorSpikes : MonoBehaviour
{
    public GameObject Spikes;
    public GameObject Offpos;
    public GameObject Onpos;
    public GameObject Midpos;
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
            StartCoroutine(SpikeOff());
        }
        SpikeMovement();

       //Debug.Log(pos);    
    }
        //Sends spikes to  mid position to indicate trap
        IEnumerator SpikeMid (){
            Spikes.transform.position = Vector3.MoveTowards(Spikes.transform.position, Midpos.transform.position, spikeSpeed );
            yield return new WaitForSeconds(2);
            pos = 2;
        }
        //Turns spike to on positon
        IEnumerator SpikeOn(){          
            Spikes.transform.position = Vector3.MoveTowards(Spikes.transform.position, Onpos.transform.position, spikeSpeed );
            yield return new WaitForSeconds(2);
            pos = 0;
        }
        //Turns spike to off position
        IEnumerator SpikeOff(){
            Spikes.transform.position = Vector3.MoveTowards(Spikes.transform.position, Offpos.transform.position, spikeSpeed );
            yield return new WaitForSeconds(2);
            pos = 1;
        }

    //Checks and Sets spikes next positon
    private void SpikeMovement(){
        if (pos == 1 && Activated == true){
            StartCoroutine(SpikeMid());
        }
        if (pos == 2 && Activated == true){
            StartCoroutine(SpikeOn());
            
        }
    }
}
