using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    public GameObject locker;
    [SerializeField]
    private GameObject derek;
    private bool isHiding;
    public bool derekActivated;
    
    public void Hide(){
        if (!isHiding){
            gameObject.transform.position = locker.transform.position;
            gameObject.transform.rotation = locker.transform.rotation;
            isHiding = true;
        }
        else{
            Vector3 tempPos = new Vector3(locker.transform.position.x, locker.transform.position.y, gameObject.transform.position.z + 1);
            gameObject.transform.position = tempPos;
            gameObject.GetComponent<MyPlayer>().enabled = true;
            isHiding = false;
        }
    }

    void Update(){
        if (isHiding && !derekActivated){
            StartCoroutine(derek.GetComponent<CameraCinematic>().Confused());
            derek.GetComponent<CameraCinematic>().isChasing = false;
            derekActivated = true;
        }
    }

}
