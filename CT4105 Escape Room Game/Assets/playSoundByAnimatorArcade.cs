using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundByAnimatorArcade : MonoBehaviour
{
    public AudioClip openDoorSound;
    public AudioClip closeDoorSound;
    public AudioSource speaker;
    // Start is called before the first frame update
    void Awake()
    {
        speaker = GetComponent<AudioSource>();
    }

    void playOpenDoorSound()
    {
        speaker.PlayOneShot(openDoorSound, 1f);
    }
    void playCloseDoorSound()
    {
        speaker.PlayOneShot(closeDoorSound, 1f);
    }


}
