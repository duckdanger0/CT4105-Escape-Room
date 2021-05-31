using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jumpscare : MonoBehaviour
{


    [SerializeField]
    private GameObject jumpscare;

    public AudioSource Audio;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Audio.Play();
            jumpscare.SetActive(true);

        }
    }
}
