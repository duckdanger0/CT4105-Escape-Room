using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMeta : MonoBehaviour
{

    [Header("Look at object properties")]
    public string _lookAtMessage;
    public float _lookAtMessageWaitTime = 2f;

    [Header("Open an object properties")]
    public string _openMessage;
    public float _openMessageWaitTime = 2f;

    [Header("Close an object properties")]
    public string _closeMessage;
    public float _closeMessageWaitTime = 2f;

    [Header("Investigate object properties")]
    public string _investigateMessage;
    public string _investigateMessageEndNotEnoughPoints;
    public float _investigateMessageWaitTime = 2f;

    [Header("After Investigating an object do you want to fade out to the new scene?")]
    public bool _fadeSceneOut = true;
    public float _fadeSceneOutSpeed = 1f;
    public int _waitTimeBeforeFadeStart = 2;
    public int _waitTimeAfterFadeEnds = 1;

     [Header("Next scene properties")]
    public string _nameOfNextSceneToGoTo;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {


    }
}
