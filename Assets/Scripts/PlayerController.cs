using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Rigidbody playerRigidbody;

    //Stores the vector used to move the player in a desired direction each physics update.
    private Vector3 inputVector;

    //Stores the speed at which the player moves in the X and Z directions.
    private float playerSpeed = 5.0f;



    //Initializations
    void Start(){

        playerRigidbody = GetComponent<Rigidbody>();

    }

    //Every frame
    void Update(){

        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * playerSpeed, playerRigidbody.velocity.y, Input.GetAxisRaw("Vertical") * playerSpeed);

        //When the player moves on the x or z axis, face that direction.
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));

    }

    //Manageing physics
    void FixedUpdate(){

        //Take the stored input vector and apply it to the player object
        playerRigidbody.velocity = inputVector;

    }

}
