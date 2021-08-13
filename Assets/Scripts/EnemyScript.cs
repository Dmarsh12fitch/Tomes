using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour{

    private GameObject player;

    //Stores the distance the player needs to be within
    private float triggerDistance = 5.0f;

    private float enemySpeed = 5.0f;


    private void Start(){

        player = GameObject.Find("Player");

    }

    void Update(){

        transform.LookAt(player.transform);

        //If the distance between the enemies position and the players position is within range
        if (Vector3.Distance(transform.position, player.transform.position) <= triggerDistance){

            transform.position += transform.forward * enemySpeed * Time.deltaTime;

        }
    }

    private void OnCollisionEnter(Collision collision){

        if(collision.gameObject.tag == "Player"){

            collision.gameObject.SetActive(false);

        }

    }

}
