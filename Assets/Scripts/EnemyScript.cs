using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour{

    private void OnCollisionEnter(Collision collision){

        if(collision.gameObject.tag == "Player"){

            collision.gameObject.SetActive(false);

        }

    }

}
