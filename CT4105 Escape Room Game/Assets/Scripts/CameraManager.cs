using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CameraManager : MonoBehaviour
{
    [HideInInspector]
    public bool _moving = false;

    [HideInInspector]
    public bool _checkFade = false;

    public string _nameOfResetParameterInAnimator;
    public ObjectsManager _objectsManager;

    public MessageManager _messageManager;

    private string _co;

    private int fingerID = -1;

    // Start is called before the first frame update
    void Start()
    {

        #if !UNITY_EDITOR

            fingerID = 0; 

        #endif

    }

    // Update is called once per frame
    void Update()
    {

        if (!_moving) 
        {

            if ( Input.GetMouseButtonUp( 0 ) )
            {

                if ( EventSystem.current.IsPointerOverGameObject( fingerID ) )    // is the touch on the GUI
                {
                    // GUI Action
                    return;
                }

                Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
                
                RaycastHit hit;
                
                if( Physics.Raycast( ray, out hit ) )
                {
                    
                    Debug.Log( hit.collider.name );
                    

                    foreach( CameraLocations _go in _objectsManager._cameraLocations )
                    {

                        _co = hit.collider.name;

                        if( _go._cameraLocation != null )
                        {
                            
                            if( hit.collider.name == _go._cameraLocation.name )
                            {
                            
                                _moving = true;

                                GetComponent<Animator>().SetTrigger( _co );

                                if( _go._cameraLocation.GetComponent<ObjectTrigger>() != null )
                                {

                                    _go._cameraLocation.GetComponent<ObjectTrigger>().enableObjectActions();

                                }                                    

                            }

                        }

                    }


                }

            }   

        }

    }

    void OnGUI()
    {

        if( GetComponent<FadeToOrFromBlack>() )
        {
            
            _checkFade = GetComponent<FadeToOrFromBlack>()._fadeToBlack;

        }

        if( !_checkFade )
        {

            Event e = Event.current;

            if ( e.isMouse )
            {

                if( e.clickCount == 2 )
                {
                    
                    _moving = false;

                    _objectsManager.disableActions( null );
                    
                    _objectsManager.hideActions();

                    GetComponent<Animator>().SetTrigger( _nameOfResetParameterInAnimator );
                    
                } 
                
            }

        } else {

            

        }
    
    }

}
