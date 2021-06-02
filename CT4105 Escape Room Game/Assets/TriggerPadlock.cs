using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPadlock : MonoBehaviour
{
    [SerializeField]
    private GameObject unlockBtn;

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            unlockBtn.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            unlockBtn.SetActive(false);
        }
    }
}
