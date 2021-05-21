using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInLocker : MonoBehaviour
{
    [SerializeField]
    private GameObject hideBtn;
    [SerializeField]
    private GameObject player;

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            hideBtn.SetActive(true);
            player.GetComponent<Hiding>().locker = gameObject;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            hideBtn.SetActive(false);
            player.GetComponent<Hiding>().derekActivated = false;
        }
    }
}
