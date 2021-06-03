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
            StartCoroutine(JumpScareAudio());
        }
    }

    private IEnumerator JumpScareAudio(){
        Audio.Play();
        jumpscare.SetActive(true);
        yield return new WaitForSeconds(2f);
        Audio.Stop();
    }
}
