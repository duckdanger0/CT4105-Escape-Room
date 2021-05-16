using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningRay : MonoBehaviour
{
    private float xRotation = 3;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity)){
            if (hit.collider.tag == "Player"){
                Debug.Log("Yes");
            }
            else{
                
            }
            if (transform.localRotation.y >= 90 && transform.localRotation.y < 270 || transform.localRotation.y <= 270 && transform.localRotation.y > 90){
                Debug.Log("No");
            }
        }



        transform.Rotate(new Vector3(0, xRotation, 0));
    }
}
