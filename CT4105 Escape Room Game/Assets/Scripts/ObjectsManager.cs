using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class CameraLocations {

	public GameObject _cameraLocation;
	
}

public class ObjectsManager : MonoBehaviour
{

    [HideInInspector]
    public string _currentAction = "";
    
    public GameObject _messageBox;

    public GameObject _lookAt;

    public GameObject _open;

    public GameObject _close;
    
    public CameraLocations[] _cameraLocations = new CameraLocations[100];

    public List<GameObject> _collectedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
  
        hideActions();

    }

    // Update is called once per frame
    void Update()
    {


    }

    
    public void hideActions()
    {

       GameObject[] _actions = GameObject.FindGameObjectsWithTag( "Action" );
 
        foreach( GameObject _go in _actions )
        {

            _go.SetActive( false );

        }  

    }



    public void enableActions()
    {

        _lookAt.SetActive( true );
        _lookAt.GetComponent<Button>().interactable = true;

        _open.SetActive( true );
        _open.GetComponent<Button>().interactable = true;

        _close.SetActive( true );
        _close.GetComponent<Button>().interactable = true;

    }

    public void disableActions( Button button )
    {

        _lookAt.GetComponent<Button>().interactable = false;

        _open.GetComponent<Button>().interactable = false;

        _close.GetComponent<Button>().interactable = false;

        if( button != null )
        {
            _currentAction = button.name;

            print( _currentAction );

        }

    }

}
