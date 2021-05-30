using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningRay : MonoBehaviour
{
    private float xRotation = 3;
    public AudioSource DerekChase;

    [SerializeField]
    private GameObject derek;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity)){
            if (hit.collider.tag == "Player" && (transform.rotation.y < 90 || transform.rotation.y > 270) && derek.GetComponent<Animator>().GetBool("Chasing") == false){
                derek.GetComponent<CameraCinematic>().isChasing = true;
                DerekChase.Play();
                derek.GetComponent<Animator>().SetBool("Caught", true);
                StartCoroutine(DelayCaught());
                derek.GetComponent<Animator>().SetBool("Chasing", true);
                derek.GetComponent<Animator>().SetBool("Left", false);
                derek.GetComponent<Animator>().SetBool("Right", false);
            }
        }
        transform.Rotate(new Vector3(0, xRotation, 0));
    }

    private IEnumerator DelayCaught(){
        yield return new WaitForSeconds(1);
        derek.GetComponent<Animator>().SetBool("Caught", false);
    }
}
