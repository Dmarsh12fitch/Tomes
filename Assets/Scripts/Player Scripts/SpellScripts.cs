﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScripts : MonoBehaviour{

    //What is the current spell the player wants to activate
    private int currentSpell = 0;



    void Update(){

        if (Input.GetKey(KeyCode.Mouse0)){

            switch (currentSpell){

                case 0:

                    //No spell is activated
                    break;

                case 1:

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

                    break;

                case 2:

                    //Get the fire spell object and make it active
                    transform.GetChild(0).gameObject.SetActive(true);

                    break;

            }

        }
        //Once left click is taken off, deactivate anything that needs to be deactivated
        else{

            //The fire spell is the first child of the player object
            transform.GetChild(0).gameObject.SetActive(false);

        }

        //Go through potential numbers to check if any are down
        for (int i = 0; i < 10; ++i){

            if (Input.GetKeyDown("" + i)){

                //Update the current selected spell if the player picks a number.
                currentSpell = i;

            }

        }

    }

}