using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Rigidbody playerRigidbody;

    //Stores the current inputs and applies speeds for player movement.
    private Vector3 inputVector;

    //Stores the speeds the player moves in each direction/action.
    private float playerSpeed = 5.0f, jumpSpeed = 8.0f;

    //Stores a check on if the player is currently on the ground, used for jumping.
    private bool isGrounded = false;



    void Start(){

        playerRigidbody = GetComponent<Rigidbody>();

    }
    
    void Update(){

        //NOTE: gravity is already affecting the y axis so simply get the current y velocity.
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * playerSpeed, playerRigidbody.velocity.y, Input.GetAxisRaw("Vertical") * playerSpeed);

        //If the player object is on the ground and the player pressed space, add an upwards force to the object.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){

            playerRigidbody.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);

        }

        //When the player moves on the x or z axis, face that direction.
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));

    }

    void FixedUpdate(){

        //Take the stored input vector and apply it to the player object.
        playerRigidbody.velocity = inputVector;

    }

    //Check if the object is touching or has left the ground and change isGrounded accordingly.
    void OnCollisionEnter(Collision collision){
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision){
        isGrounded = false;
    }

}
