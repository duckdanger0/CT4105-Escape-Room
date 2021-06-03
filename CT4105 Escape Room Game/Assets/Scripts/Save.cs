using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Save : MonoBehaviour
{

    public string currentScene;


    void Start()
    {
        
    }

    public void save()
    {
        PlayerPrefs.SetString("GameSav", currentScene);
    }

}
