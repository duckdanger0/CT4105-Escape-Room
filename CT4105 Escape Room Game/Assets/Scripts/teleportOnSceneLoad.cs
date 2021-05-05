using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportOnSceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalControl.Instance.posx == 0f)
        {
            GameObject player = GameObject.Find("Player");
            Debug.Log("Teleporting to Default Location");
            player.transform.position = new Vector3(12.52659f, 2f, 7.661397f);
            player.transform.rotation = Quaternion.Euler(0, 196.107f, 0);
        }
        else
        {
            transform.position = new Vector3(GlobalControl.Instance.posx, GlobalControl.Instance.posy, GlobalControl.Instance.posz);
            transform.rotation = Quaternion.Euler(0, GlobalControl.Instance.roty, 0);


        }
    }
}