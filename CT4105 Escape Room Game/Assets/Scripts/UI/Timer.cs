using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private string newLevel;
    public float timer = 30f;

    int seconds;

    // Start is called before the first frame update
    void Start()
    {

        seconds = 0;

        timer += 1;

    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        seconds = ( int )( timer );

        if ( seconds < 1 )
        {

            SceneManager.LoadScene(newLevel);

        }

    }

}
