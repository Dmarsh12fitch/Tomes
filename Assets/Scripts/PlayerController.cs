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

        //Get the direction the user inputed and put the walking speed in that axis of the vector.
        //Gravity is already affecting the y axis so put that into the y axis of the vector.
        inputVector = new Vector3
        (Input.GetAxisRaw("Horizontal") * playerSpeed, playerRigidbody.velocity.y, Input.GetAxisRaw("Vertical") * playerSpeed);

        //Essentially the front of the object the objects position +1 in the direction the user inputed.
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){

            //Add an upwards force at the jumpSpeed set, apply it instantly.
            playerRigidbody.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);

            isGrounded = false;

        }


        //WIP.
        if (Input.GetKey(KeyCode.Mouse0)){

            //Send out a ray from the camera to where the user is clicking on the screen.
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit mouseHit;

            Vector3 mouseCollisionPoint = Vector3.zero;

            //Use that ray to then find the point on the map the user is trying to send the spell.
            if (Physics.Raycast(mouseRay, out mouseHit)){

                mouseCollisionPoint = mouseHit.point;

            }

            
            RaycastHit spellHit;

            //Send out a line from the player object to the object they want to point the spell at and check for line collisions.
            if (Physics.Linecast(gameObject.transform.position, mouseCollisionPoint, out spellHit)){

                Vector3 forceDirection = spellHit.point - gameObject.transform.position;

                //Add force to objects hit within the spell.
                spellHit.rigidbody.AddForce(forceDirection * 10, ForceMode.Force);

            }

            Debug.DrawLine(mouseCollisionPoint, gameObject.transform.position, Color.red);

        }



    }

    void FixedUpdate(){

        //Take the stored input vector and apply it to the player object.
        playerRigidbody.velocity = inputVector;


        // Get the velocity of the rigidbody but ignore the yaxis value.
        Vector3 horizontalMovement = playerRigidbody.velocity;
        horizontalMovement.y = 0;
        //This is the distance that the player object will be moved in a given physics update.
        float distance = horizontalMovement.magnitude * Time.fixedDeltaTime;
        horizontalMovement.Normalize();
        //Use raycasting to detect future collisions in a direction.
        RaycastHit hit;

        //Sweeptest checks if the rigidbody would collide when moved through the scene.
        if (playerRigidbody.SweepTest(horizontalMovement, out hit, distance)){

            //During a collision the object should simply fall rather than move in any other axis.
            playerRigidbody.velocity = new Vector3(0, playerRigidbody.velocity.y, 0);

        }


    }


    //Check if the object has started touching the ground and change isGrounded accordingly.
    void OnCollisionEnter(Collision collision){
        isGrounded = true;
    }

}
