using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadlockActive : MonoBehaviour
{
    [SerializeField]
    private GameObject padlockCamera;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject btn;
    [SerializeField]
    private GameObject checkbtn;

    public void Unlock(){
        padlockCamera.SetActive(true);
        checkbtn.SetActive(true);
        player.SetActive(false);
        btn.SetActive(false);
    }
}
