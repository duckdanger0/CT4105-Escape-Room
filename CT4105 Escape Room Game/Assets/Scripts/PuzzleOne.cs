using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PuzzleOne : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goBackToEscapeRoom( string escapeRoomGameScene )
    {
       
        PlayerPrefs.SetInt( "score", 1 );

        PlayerPrefs.SetString( "puzzleOne", "Complete" );

        PlayerPrefs.Save();

        SceneManager.LoadScene( escapeRoomGameScene );  

    }

}
