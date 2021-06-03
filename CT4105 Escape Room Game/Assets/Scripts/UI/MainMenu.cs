using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator fadeAnim;
    [SerializeField]
    private GameObject fade;

 

    public string gotoThisScene;

    public void PlayGame()
    {
        SceneManager.LoadScene(gotoThisScene);
    }
    public void QuitGamee()
    {
        Application.Quit();
    }

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

}
