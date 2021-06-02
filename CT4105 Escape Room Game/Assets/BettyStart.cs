using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BettyStart : MonoBehaviour
{
    [SerializeField]
    private GameObject betty;
    [SerializeField]
    private GameObject doorL;
    [SerializeField]
    private GameObject doorR;

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            betty.SetActive(true);
            doorL.GetComponent<Animator>().enabled = true;
            doorR.GetComponent<Animator>().enabled = true;
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay(){
        yield return new WaitForSeconds(2);
        betty.GetComponent<FollowPlayer>().enabled = true;
    }
}
