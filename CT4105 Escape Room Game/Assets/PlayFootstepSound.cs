using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootstepSound : MonoBehaviour
{
    public AudioSource speaker;
    public AudioClip walk;
    public Rigidbody playerRB;
    Vector3 lastPos;


    void Update()
    {
        if (playerRB.transform.position != lastPos)
        {
            if (!speaker.isPlaying)
            {
                speaker.PlayOneShot(walk, 1f);
            }
        }
        lastPos = playerRB.transform.position;
    }


}
