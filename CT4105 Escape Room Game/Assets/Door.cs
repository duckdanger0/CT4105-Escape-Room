using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField]
    private GameObject QTE;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject button;

    QTE qteScript;



    public bool locked;

        void Start()
        {
            text.SetActive(false);
            button.SetActive(false);
            qteScript = GameObject.Find("QTE").GetComponent<QTE>();
        }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && qteScript.locked == false)
        {
            button.SetActive(true);

        }else if (other.tag == "Player" && qteScript.locked == true)
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text.SetActive(false);
            button.SetActive(false);
        }
    }
}
