using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class ObjectTrigger : MonoBehaviour
{

    [Header("Does this object have animation?")]
    public Animator _objectAnimator;
    public string _objectAnimatorActivateParameterName = "Open";
    public string _objectAnimatorDeactivateParameterName = "Close";

    [HideInInspector]
    public bool _activated = false;

    [Header("Does the object require another object to trigger the animation?")]  
    public GameObject _requiredGameObjectToTrigger;
    public string _requiredGameObjectMessage;
    public float _requiredGameObjectMessageWaitTime = 2f;
    public string _newLookAtMessageAfterActivated;  
    public float _newLookAtMessageWaittimeAfterActivated = 2f;  


    [Header("What actions does this object offer?")]   
    public bool _lookAt;
    public bool _open;
    public bool _close;
    public bool _investigate;
    public bool TheEnd;

    private GameObject _mc;
    private ObjectsManager _om;
    private MessageManager _mm;
    private int _fingerID = -1;

    // Start is called before the first frame update
    void Start()
    {

        #if !UNITY_EDITOR

            _fingerID = 0; 

        #endif

        _mc = GameObject.FindGameObjectWithTag( "MainCamera" );

        _om = _mc.GetComponent<ObjectsManager>();

        _mm = _mc.GetComponent<CameraManager>()._messageManager;

    }

    // Update is called once per frame
    void Update()
    {
        
        if ( _mc.GetComponent<CameraManager>()._moving ) 
        {
            
            if ( Input.GetMouseButtonUp( 0 ) )
            {

                if ( EventSystem.current.IsPointerOverGameObject( _fingerID ) )
                {

                    // GUI Action
                    return;

                }

                if ( !_mc.GetComponent<CameraManager>()._checkFade )
                {

                    Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
                    
                    RaycastHit hit;
                    
                    if( Physics.Raycast( ray, out hit ) )
                    {
                                        
                        if( hit.collider.name == gameObject.name )                    
                        {

                            Debug.Log( hit.collider.name );

                            if( !_activated )
                            {

                                enableObjectActions();
                                
                                switch( _om._currentAction )
                                {

                                    case "LookAt":

                                        _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._lookAtMessage, gameObject.GetComponent<ObjectMeta>()._lookAtMessageWaitTime );

                                    break;

                                    case "Open":
                                    
                                        if( !_activated )
                                        {

                                            foreach( GameObject _co in _om._collectedObjects )
                                            {

                                                if( _co != null )
                                                {

                                                    if( _co.name == _requiredGameObjectToTrigger.name )
                                                    {

                                                        _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._openMessage, gameObject.GetComponent<ObjectMeta>()._openMessageWaitTime );

                                                        GetComponent<Animator>().SetTrigger( _objectAnimatorActivateParameterName );

                                                        _activated = true;

                                                        _om._currentAction = "";

                                                        return;

                                                    }    

                                                }                                   

                                            }
                                                    
                                            _mm.showMessage( _requiredGameObjectMessage, _requiredGameObjectMessageWaitTime );

                                        } else {

                                            _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._openMessage, gameObject.GetComponent<ObjectMeta>()._openMessageWaitTime );

                                            GetComponent<Animator>().SetTrigger( _objectAnimatorActivateParameterName );

                                            _om.hideActions();

                                            _om.disableActions( null );

                                        }

                                    break;

                                    case "Close":

                                        if( !_activated )
                                        {
                                            
                                            _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._closeMessage, gameObject.GetComponent<ObjectMeta>()._closeMessageWaitTime );

                                        } else {

                                            _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._closeMessage, gameObject.GetComponent<ObjectMeta>()._closeMessageWaitTime );

                                            GetComponent<Animator>().SetTrigger( _objectAnimatorDeactivateParameterName );
                                            
                                            _om.hideActions();

                                            _om.disableActions( null );

                                        }

                                    break;

                                    case "Investigate":
                                        
                                        if (TheEnd)
                                        {
                                            if (GlobalControl.Instance.score != 300)
                                            {
                                                _mm.showMessage(gameObject.GetComponent<ObjectMeta>()._investigateMessageEndNotEnoughPoints, gameObject.GetComponent<ObjectMeta>()._investigateMessageWaitTime);
                                                break;
                                            }
                                            
                                        }

                                        _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._investigateMessage, gameObject.GetComponent<ObjectMeta>()._investigateMessageWaitTime );

                                        if( _mc.GetComponent<FadeToOrFromBlack>() == null )
                                        {     

                                            StartCoroutine( loadNextScene( gameObject.GetComponent<ObjectMeta>()._investigateMessageWaitTime ) );

                                        } else {


                                            if( gameObject.GetComponent<ObjectMeta>()._fadeSceneOut )
                                            {
                                                
                                                _mc.GetComponent<FadeToOrFromBlack>().fadeToBlack( gameObject.GetComponent<ObjectMeta>()._fadeSceneOutSpeed, 
                                                                                            gameObject.GetComponent<ObjectMeta>()._waitTimeBeforeFadeStart,
                                                                                            gameObject.GetComponent<ObjectMeta>()._waitTimeAfterFadeEnds, 
                                                                                            gameObject.GetComponent<ObjectMeta>()._nameOfNextSceneToGoTo );

                                            } else {

                                                _mc.GetComponent<FadeToOrFromBlack>().fadeToBlack( 10000, 
                                                                                                   gameObject.GetComponent<ObjectMeta>()._waitTimeBeforeFadeStart, 
                                                                                                   0, 
                                                                                                   gameObject.GetComponent<ObjectMeta>()._nameOfNextSceneToGoTo );

                                            }

                                        }

                                    break;

                                }             

                                _om._currentAction = "";

                            } else {

                                enableObjectActions();

                                switch( _om._currentAction )
                                {

                                    case "Look_At":

                                        _mm.showMessage( _newLookAtMessageAfterActivated, _newLookAtMessageWaittimeAfterActivated );

                                    break;

                                    case "Open":
                                    
                                        _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._openMessage, gameObject.GetComponent<ObjectMeta>()._openMessageWaitTime );

                                        GetComponent<Animator>().SetTrigger( _objectAnimatorActivateParameterName );
                                        
                                        _om.hideActions();

                                        _om.disableActions( null );

                                    break;

                                    case "Close":

                                        _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._closeMessage, gameObject.GetComponent<ObjectMeta>()._closeMessageWaitTime );

                                        GetComponent<Animator>().SetTrigger( _objectAnimatorDeactivateParameterName );

                                        _om.hideActions();

                                        _om.disableActions( null ); 

                                    break;

                                    case "Investigate":
                          
                                        _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._investigateMessage, gameObject.GetComponent<ObjectMeta>()._investigateMessageWaitTime );

                                        if( _mc.GetComponent<FadeToOrFromBlack>() == null )
                                        {     

                                            StartCoroutine( loadNextScene( gameObject.GetComponent<ObjectMeta>()._investigateMessageWaitTime ) );

                                        } else {


                                            if( gameObject.GetComponent<ObjectMeta>()._fadeSceneOut )
                                            {
                                                
                                                _mc.GetComponent<FadeToOrFromBlack>().fadeToBlack( gameObject.GetComponent<ObjectMeta>()._fadeSceneOutSpeed, 
                                                                                            gameObject.GetComponent<ObjectMeta>()._waitTimeBeforeFadeStart, 
                                                                                            gameObject.GetComponent<ObjectMeta>()._waitTimeAfterFadeEnds, 
                                                                                            gameObject.GetComponent<ObjectMeta>()._nameOfNextSceneToGoTo );

                                            } else {

                                                _mc.GetComponent<FadeToOrFromBlack>().fadeToBlack( 10000, 
                                                                                                   gameObject.GetComponent<ObjectMeta>()._waitTimeBeforeFadeStart, 
                                                                                                   0, 
                                                                                                   gameObject.GetComponent<ObjectMeta>()._nameOfNextSceneToGoTo );

                                            }

                                        }

                                    break;

                                }             

                                _om._currentAction = "";
                            
                            }

                        }
                            
                    }
                    
                }

            }   

        }

    }

    public void enableObjectActions()
    {

        if( _lookAt )
        {
            
            _om._lookAt.SetActive( true );

            _om._lookAt.GetComponent<Button>().interactable = true;

        } else {

            _om._lookAt.SetActive( false );

        }

        if( _open )
        {
            
            _om._open.SetActive( true );

            _om._open.GetComponent<Button>().interactable = true;

        } else {

            _om._open.SetActive( false );

        }

        if( _close )
        {
            
            _om._close.SetActive( true );

            _om._close.GetComponent<Button>().interactable = true;

        } else {

            _om._close.SetActive( false );

        }

        if( _investigate )
        {
            
            _om._investigate.SetActive( true );

            _om._investigate.GetComponent<Button>().interactable = true;

        } else {

            _om._investigate.SetActive( false );

        }

    }

    IEnumerator loadNextScene( float waitTime )
    {
        
        _mc.GetComponent<CameraManager>()._checkFade = true;

        _om.hideActions();

        _om.disableActions( null );

        // Save player position

        GameObject player = GameObject.Find("Player");
        GlobalControl.Instance.posx = player.transform.position.x;
        GlobalControl.Instance.posy = player.transform.position.y;
        GlobalControl.Instance.posz = player.transform.position.z;
        GlobalControl.Instance.roty = player.transform.localRotation.eulerAngles.y;

        if (TheEnd)
        {
            GameObject brain = GameObject.Find("theallknowingcube");
            Destroy(brain);
        }

        yield return new WaitForSeconds( waitTime );

        SceneManager.LoadScene( gameObject.GetComponent<ObjectMeta>()._nameOfNextSceneToGoTo );        
       
    }     

}
