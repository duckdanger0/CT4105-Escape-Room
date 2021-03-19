using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightLine : MonoBehaviour
{

    [SerializeField]
    GameObject Jaakko;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {

            if (hit.transform.tag == "Jaakko")
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
            Jaakko.GetComponent<Jaakko>().Speed = 5f;
        }
    }
}
