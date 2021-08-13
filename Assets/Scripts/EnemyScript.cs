using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour{

    private GameObject player;
    private Rigidbody rigidBody;

    //Stores the distance the player needs to be within
    private float triggerDistance = 5.0f;

    private float enemySpeed = 5.0f;


    private void Start(){

        player = GameObject.Find("Player");
        rigidBody = gameObject.GetComponent<Rigidbody>();

    }

    void Update(){

        Vector3 direction = player.transform.position - transform.position;

        direction.Normalize();

        //If the distance between the enemies position and the players position is within range
        if (Vector3.Distance(transform.position, player.transform.position) <= triggerDistance){

            Vector3 addedVelocity = direction * enemySpeed;

            rigidBody.velocity = new Vector3(addedVelocity.x, rigidBody.velocity.y, addedVelocity.z);

        }
    }

    private void OnCollisionEnter(Collision collision){

        if(collision.gameObject.tag == "Player"){

            collision.gameObject.SetActive(false);

        }

    }

}
