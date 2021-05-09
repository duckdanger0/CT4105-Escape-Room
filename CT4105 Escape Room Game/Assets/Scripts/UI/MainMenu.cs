using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string gotoThisScene;

    public void PlayGame()
    {
        SceneManager.LoadScene(gotoThisScene);
    }
    public void QuitGamee()
    {
        Application.Quit();
    }


}
