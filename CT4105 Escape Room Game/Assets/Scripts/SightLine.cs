using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {

            GameObject Jaakko = hit.transform.gameObject;

            if (Jaakko.tag == "Jaakko")
            {
                Jaakko.GetComponent<Jaakko>().Speed = 0f;
            }
            else
            {
                Jaakko.GetComponent<Jaakko>().Speed = 5f;
            }
        }
        else
        {
            GameObject Jaakko = hit.transform.gameObject;
            Jaakko.GetComponent<Jaakko>().Speed = 5f;
        }
    }
}
