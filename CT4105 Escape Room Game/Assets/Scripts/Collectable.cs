using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour
{

    public string _collectMessage;
    public float _collectMessageWaitTime = 2f;

    private GameObject _mc;
    private ObjectsManager _om;
    private MessageManager _mm;

    // Start is called before the first frame update
    void Start()
    {

        _mc = GameObject.FindGameObjectWithTag( "MainCamera" );

        _om = _mc.GetComponent<ObjectsManager>();

        _mm = _mc.GetComponent<CameraManager>()._messageManager;
        
    }

    // Update is called once per frame
    void Update()
    {


    }
    
    private void OnMouseDown()
    {

        _mm.showMessage( _collectMessage, _collectMessageWaitTime );
        
        _om._collectedObjects.Add( gameObject );

        gameObject.SetActive( false );

    }

}
