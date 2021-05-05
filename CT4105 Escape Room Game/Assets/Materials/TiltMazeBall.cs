using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltMazeBall : MonoBehaviour
{

    public GameObject targetToHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter( Collision collision )
    {
        if( collision.gameObject.name == targetToHit.name )
        {
            GlobalControl.Instance.score = +100;
            GameObject.Find("TiltMazeManager").GetComponent<TiltMazeManager>().complete = true;

        }
        
    }
}
