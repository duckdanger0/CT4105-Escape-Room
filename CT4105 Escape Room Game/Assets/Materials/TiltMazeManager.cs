using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiltMazeManager : MonoBehaviour
{

    private Touch touch;

    private Vector2 touchPosition;

    private Quaternion rotationX, rotationZ;

    public GameObject ObjectToRotate;
    
    public float tiltSpeedModifier = 0.02f;

    public bool complete = false;

    public string nameOfPuzzle, escapeRoomGameScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if( Input.touchCount > 0 )
        {
        
            touch = Input.GetTouch( 0 );

            switch( touch.phase )
            {

                case TouchPhase.Moved:

                    rotationX = Quaternion.Euler( -touch.deltaPosition.x * tiltSpeedModifier, 0f, 0f );

                    ObjectToRotate.transform.rotation = rotationX * ObjectToRotate.transform.rotation;

                    rotationZ = Quaternion.Euler( 0f, 0f, -touch.deltaPosition.y * tiltSpeedModifier );

                    ObjectToRotate.transform.rotation = ObjectToRotate.transform.rotation * rotationZ;

                break;

            }

        }

        if( complete )
        {

            PlayerPrefs.SetInt( "Score", PlayerPrefs.GetInt( "Score" ) + 1 );

            PlayerPrefs.SetString( nameOfPuzzle, "Complete" );

            PlayerPrefs.Save();

            SceneManager.LoadScene( escapeRoomGameScene );  
            
        }
        
    }

}
