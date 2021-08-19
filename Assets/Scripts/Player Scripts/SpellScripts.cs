using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScripts : MonoBehaviour{

    //What is the current spell the player wants to activate.
    private int currentSpell = 0;

    //The force that is added to the object when hit by the wind spell.
    private float windStrength = 800.0f;



    void Update() {

        //Go through potential numbers to check if any are down.
        for (int i = 0; i < 10; ++i) {

            if (Input.GetKeyDown("" + i)) {

                //Update the current selected spell if the player picks a number.
                currentSpell = i;

            }

        }

        if (Input.GetKey(KeyCode.Mouse0)) {

            switch (currentSpell) {

                case 0:

                    //No spell is activated
                    break;

                //Wind Spell
                case 1:

                    //Send out a ray from the camera to where the user is clicking on the screen.
                    Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                    RaycastHit mouseHit;

                    Vector3 mouseCollisionPoint = Vector3.zero;

                    //Use that ray to then find the point on the map the user is trying to send the spell.
                    if (Physics.Raycast(mouseRay, out mouseHit)) {

                        mouseCollisionPoint = mouseHit.point;

                    }


                    RaycastHit spellHit;

                    //Send out a line from the player object to the object they want to point the spell at and check for line collisions.
                    if (Physics.Linecast(gameObject.transform.position, mouseCollisionPoint, out spellHit)) {

                        Vector3 forceDirection = spellHit.point - gameObject.transform.position;

                        //Add force to objects hit within the spell. Divide the wind power by the distance to make the spell weaker from far away.
                        spellHit.rigidbody.AddForce(forceDirection * (windStrength / Vector3.Distance(spellHit.point, gameObject.transform.position)), ForceMode.Force);

                    }

                    Debug.DrawLine(mouseCollisionPoint, gameObject.transform.position, Color.red);

                    break;

                //Fire Spell
                case 2:

                    //Get the fire spell object and make it active
                    transform.GetChild(0).gameObject.SetActive(true);

                    break;

                //Ice Spell
                case 3:

                    //Send out a ray from the camera to where the user is clicking on the screen.
                    Ray mouseRayIce = Camera.main.ScreenPointToRay(Input.mousePosition);

                    RaycastHit mouseHitIce;

                    if (Physics.Raycast(mouseRayIce, out mouseHitIce)) {

                        //If the object clicked is an enemy, freeze the enemy script using the FreezeEnemy coroutine.
                        if (mouseHitIce.rigidbody.gameObject.CompareTag("Enemy")){

                            GameObject enemy = mouseHitIce.rigidbody.gameObject;

                            //Remove the friction coming from the object itself.
                            enemy.GetComponent<Collider>().material.staticFriction = 0.0f;
                            enemy.GetComponent<Collider>().material.dynamicFriction = 0.0f;

                            //Give the object a blue color
                            enemy.GetComponent<Renderer>().material.color = new Color32(117, 216, 230, 255);

                            StartCoroutine("FreezeEnemy", enemy);

                        }
                        else{

                            GameObject frozenObject = mouseHitIce.rigidbody.gameObject;

                            //Remove the friction coming from the object itself.
                            frozenObject.GetComponent<Collider>().material.staticFriction = 0.0f;
                            frozenObject.GetComponent<Collider>().material.dynamicFriction = 0.0f;

                            //Give the object a blue color
                            frozenObject.GetComponent<Renderer>().material.color = new Color32(117, 216, 230, 255);

                        }

                    }

                    break;

                //Geo Spell
                case 4:

                    if (Input.GetKeyDown(KeyCode.Mouse0)) {

                        GameObject[] platforms;
                        platforms = GameObject.FindGameObjectsWithTag("EarthPlatform");

                        //Go through the platforms in the scene
                        foreach (GameObject p in platforms) {

                            //Get the status of if the platform in the scene is activated or not.
                            bool platformActivation = p.GetComponent<EarthPlatform>().Activated;

                            //If it is not activated, activated it, otherwise deactivate it.
                            if (platformActivation == false) {

                                platformActivation = true;

                            }
                            else {

                                platformActivation = false;

                            }

                            //Send the new status out to the platform.
                            p.GetComponent<EarthPlatform>().Activated = platformActivation;


                        }

                    }

                    break;

            }

        }

        //Once left click is taken off, deactivate anything that needs to be deactivated
        else {

            //The fire spell is the first child of the player object
            transform.GetChild(0).gameObject.SetActive(false);

        }

    }

    IEnumerator FreezeEnemy(GameObject enemy){

        //Disable the enemy script itself, should stop it from moving and disabling the player
        enemy.GetComponent<EnemyScript>().enabled = false;

        yield return new WaitForSeconds(2);

        //After two seconds it thaws and comes back
        enemy.GetComponent<EnemyScript>().enabled = true;
        enemy.GetComponent<Renderer>().material.color = new Color32(255, 42, 42, 255);

    }

}
