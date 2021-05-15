using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeToOrFromBlack : MonoBehaviour
{
    
    [HideInInspector]
    public bool _fadeToBlack = false;

    [HideInInspector]
    float _fadeAmount;

    public GameObject _blackOutSquare;

    public bool fadeSceneIn = true;
    public float fadeSceneInSpeed = 0.5f;

    void Start() 
    {
        if( fadeSceneIn )
        {

           fadeFromBlack( fadeSceneInSpeed, 0, 0 );

        }

    }

    
    public void fadeToBlack( float fadeSpeed = 1, int waitBeforeFade = 2, int waitAfterFade = 2, string nextSceneToLoad = "" )
    {

        _fadeToBlack = true;

        StartCoroutine( FadeBlackOutSquare( _fadeToBlack, fadeSpeed, waitBeforeFade, waitAfterFade, nextSceneToLoad ) );

    }
    public void fadeFromBlack( float fadeSpeed = 1, int waitBeforeFade = 0, int waitAfterFade = 0 )
    {
        
        _fadeToBlack = false;

        StartCoroutine( FadeBlackOutSquare( _fadeToBlack, fadeSpeed, waitBeforeFade, waitAfterFade, null ) );
        
    }    

    public IEnumerator FadeBlackOutSquare( bool fadeToBlack, float fadeSpeed, int waitBeforeFade, int waitAfterFade, string nextSceneToLoad )
    {

        if( _blackOutSquare != null )
        {

            if( fadeToBlack )
            {
                Color objectColour = _blackOutSquare.GetComponent<Image>().color;

                objectColour = new Color( objectColour.r, objectColour.g, objectColour.b, 0 );

                _blackOutSquare.GetComponent<Image>().raycastTarget = true;

                yield return new WaitForSeconds( waitBeforeFade );

                while( _blackOutSquare.GetComponent<Image>().color.a < 1 )
                {

                    _fadeAmount = objectColour.a + ( fadeSpeed * Time.deltaTime );

                    objectColour = new Color( objectColour.r, objectColour.g, objectColour.b, _fadeAmount );

                    _blackOutSquare.GetComponent<Image>().color = objectColour;

                    yield return null;

                }

            } else {

                _blackOutSquare.GetComponent<Image>().raycastTarget = true;
                
                Color objectColour = _blackOutSquare.GetComponent<Image>().color;

                objectColour = new Color( objectColour.r, objectColour.g, objectColour.b, 1 );

                _blackOutSquare.GetComponent<Image>().color = objectColour;
                                
                yield return new WaitForSeconds( waitBeforeFade );

                while( _blackOutSquare.GetComponent<Image>().color.a > 0 )
                {

                    _fadeAmount = objectColour.a - ( fadeSpeed * Time.deltaTime );

                    objectColour = new Color( objectColour.r, objectColour.g, objectColour.b, _fadeAmount );

                    _blackOutSquare.GetComponent<Image>().color = objectColour;

                    yield return null;

                }

                _blackOutSquare.GetComponent<Image>().raycastTarget = false;

            }
            
            yield return new WaitForSeconds( waitAfterFade );

            if( nextSceneToLoad != null )
            {
                // Save player position
                Scene currentScene = SceneManager.GetActiveScene();
                string sceneName = currentScene.name;
                if (sceneName == "Floor 2 - Arcade")
                {
                    GameObject player = GameObject.Find("Player");
                    Debug.Log(player);
                    GlobalControl.Instance.posx = player.transform.position.x;
                    GlobalControl.Instance.posy = player.transform.position.y;
                    GlobalControl.Instance.posz = player.transform.position.z;
                    GlobalControl.Instance.roty = player.transform.localRotation.eulerAngles.y;
                    SceneManager.LoadScene(nextSceneToLoad);
                }
                else
                {
                    SceneManager.LoadScene(nextSceneToLoad);
                }
            }
        }
    }
}
