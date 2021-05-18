using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour{

    public AudioSource impactSound;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.z > 0)
        {
            impactSound.Play();
        }
    }










}