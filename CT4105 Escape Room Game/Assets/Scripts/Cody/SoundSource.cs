using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    [SerializeField]
    private GameObject cody;
    [SerializeField]
    private GameObject playBtn;

    public void PlaySound(){
        cody.GetComponent<CodyAI>().isAttracted = true;
        cody.GetComponent<CodyAI>().soundSource = gameObject;
        Debug.Log("yes");
    }

    private void OnTriggerEnter(Collider other){
        if (other.tag == "Cody"){
            StartCoroutine(cody.GetComponent<CodyAI>().Confused());
        }
        if (other.tag == "Player"){
            playBtn.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player")
        {
            playBtn.SetActive(false);
        }
    }
}
