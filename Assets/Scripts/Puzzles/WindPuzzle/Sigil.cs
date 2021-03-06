using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigil : MonoBehaviour
{
    // Lets you chose the Sigil type in the inspector 
    public enum SigilType
    {
        Wind,
        Fire,
        Earth
    }

    public SigilType sigilType;

    public bool activated = false;


    private void OnTriggerEnter(Collider other)
    {
        // if the other object's tag matches the sigil type then the sigil gets activated
        activated = other.gameObject.CompareTag(sigilType.ToString());
    }

    // if the matching object leaves the platform the sigil is deactivated 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(sigilType.ToString()))
        {
            activated = false;
        }
    }
}
