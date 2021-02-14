using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ObjectTrigger : MonoBehaviour
{

    public Animator _objectAnimator;
    public bool _activated = false;
    public GameObject _requiredGameObjectToTrigger;

    public string _requiredGameObjectMessage;
    public float _requiredGameObjectMessageWaitTime = 2f;        
    public bool _lookAt;
    public bool _open;
    public bool _close;

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

                                case "Look_At":

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

                                                    GetComponent<Animator>().SetTrigger( "Open" );

                                                    _activated = true;

                                                    _om._currentAction = "";

                                                    return;

                                                }    

                                            }                                   

                                        }
                                                
                                        _mm.showMessage( _requiredGameObjectMessage, _requiredGameObjectMessageWaitTime );

                                    } else {

                                        _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._openMessage, gameObject.GetComponent<ObjectMeta>()._openMessageWaitTime );

                                        GetComponent<Animator>().SetTrigger( "Open" );

                                    }

                                break;

                                case "Close":

                                    if( !_activated )
                                    {
                                        
                                        _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._closeMessage, gameObject.GetComponent<ObjectMeta>()._closeMessageWaitTime );

                                    } else {

                                        _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._closeMessage, gameObject.GetComponent<ObjectMeta>()._closeMessageWaitTime );

                                        GetComponent<Animator>().SetTrigger( "Close" );

                                    }

                                break;

                            }             

                            _om._currentAction = "";

                        } else {

                            enableObjectActions();

                            switch( _om._currentAction )
                            {

                                case "Look_At":

                                    _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._lookAtMessage, gameObject.GetComponent<ObjectMeta>()._lookAtMessageWaitTime );

                                break;

                                case "Open":
                                
                                    _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._openMessage, gameObject.GetComponent<ObjectMeta>()._openMessageWaitTime );

                                    GetComponent<Animator>().SetTrigger( "Open" );

                                break;

                                case "Close":

                                    _mm.showMessage( gameObject.GetComponent<ObjectMeta>()._closeMessage, gameObject.GetComponent<ObjectMeta>()._closeMessageWaitTime );

                                    GetComponent<Animator>().SetTrigger( "Close" );

                                break;

                            }             

                            _om._currentAction = "";
                        
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

    }    

}
