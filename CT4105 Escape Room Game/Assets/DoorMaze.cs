using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorMaze : MonoBehaviour
{
    [SerializeField]
    private Animator fadeAnim;
    [SerializeField]
    private GameObject fade;
    [SerializeField]
    private GameObject button;



    public string gotoThisScene;
    public void sceneChange()
    {
        Debug.Log("change");
        Invoke("sceneChange2", 1);
        fadeAnim.SetBool("W2B", true);
    }

    private void sceneChange2()
    {
        SceneManager.LoadScene(gotoThisScene);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            button.SetActive(true);
        }
    }
}
