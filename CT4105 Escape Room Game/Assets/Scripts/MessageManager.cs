using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageManager : MonoBehaviour
{

    Coroutine _messageReset;

    private ObjectsManager _om;

    // Start is called before the first frame update
    void Start()
    {

        _om =  GameObject.FindGameObjectWithTag( "MainCamera" ).GetComponent<ObjectsManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showMessage( string message, float wait )
    {

        _om._messageBox.GetComponent<TextMeshProUGUI>().text =  message ;

        if( _messageReset != null )
         {

            StopCoroutine( _messageReset );

            _messageReset = null;

        }

        _messageReset = StartCoroutine( clearMessage( wait ) );

    }

    IEnumerator clearMessage( float waitTime )
    {
         
        yield return new WaitForSeconds( waitTime );

        _om._messageBox.GetComponent<TextMeshProUGUI>().text =  "";
        
       
    } 

}
