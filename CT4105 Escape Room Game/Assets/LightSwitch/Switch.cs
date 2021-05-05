using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public GameObject up;
    public GameObject on;
    public GameObject down;
    public GameObject off;
    public bool switchValue;

    void Update()
    {

        if (switchValue == true)
        {
            on.SetActive(true);
            up.SetActive(true);
            down.SetActive(false);
            off.SetActive(false);
        }
        else
        {
            on.SetActive(false);
            up.SetActive(false);
            down.SetActive(true);
            off.SetActive(true);
        }

    }
    void OnMouseDown()
    {
        switchValue = !switchValue;
    }
}

