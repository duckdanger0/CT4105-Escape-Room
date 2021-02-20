using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    // Start is called before the first frame update
    string puzzle1Status;

    void Start()
    {

        puzzle1Status = PlayerPrefs.GetString( "puzzleOne" );

        if( puzzle1Status == "" )
        {

            puzzle1Status = "Incomplete";

        }

        print( "Puzzle One is: " + puzzle1Status );

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deletePlayerPrefs()
    {

        PlayerPrefs.DeleteAll();

        print( "PlayerPrefs deleted." );

    }

}
