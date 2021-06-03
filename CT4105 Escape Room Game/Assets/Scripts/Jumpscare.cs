using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    [SerializeField]
    private GameObject jumpscare;
    public AudioSource Audio;
    public string gotoThisScene = "Game Over";

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
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(gotoThisScene);
        Audio.Stop();
    }
}
