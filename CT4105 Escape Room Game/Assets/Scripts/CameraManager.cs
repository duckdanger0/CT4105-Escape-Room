using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraObject {

	public string gameObjectName;
	
}

public class CameraManager : MonoBehaviour
{

    public CameraObject[] listOfGameObjectsToMoveTo = new CameraObject[100];

    public string nameOfResetParameterInAnimator;

    private string _co ;

    private bool _moving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!_moving) 
        {
            if ( Input.GetMouseButtonUp( 0 ) )
            {

                Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
                
                RaycastHit hit;
                
                if( Physics.Raycast( ray, out hit ) )
                {
                    
                    //Debug.Log( hit.collider.name );

                    foreach( CameraObject _go in listOfGameObjectsToMoveTo )
                    {

                        _co = hit.collider.name;

                        if( hit.collider.name == _go.gameObjectName )
                        {
                        
                            _moving = true;

                            GetComponent<Animator>().SetTrigger( _co );
                        }

                    }
                    
                }

            }   

        }

    }

    void OnGUI()
    {
        
        Event e = Event.current;

        if ( e.isMouse )
        {

            if( e.clickCount == 2 )
            {
                
                _moving = false;

                GetComponent<Animator>().SetTrigger( nameOfResetParameterInAnimator );
                
            }

        }

    }

}
