using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QTE : MonoBehaviour
{


    SoundSource sound;

    [SerializeField]
    private GameObject Btn;
    [SerializeField]
    private GameObject exit;
    [SerializeField]
    private GameObject ring;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject play;
    [SerializeField]
    private GameObject ticketCounter;


    public AudioSource Awin;
    public AudioSource lose;

    public bool loss;
    public bool locked;
    public bool start;

    //public float fillAmnt = 0;
    public float ringTime;
    public float dificulty = 1;
    private float level = 0f;
    private float time = 1f;
    public float f;


    public void Begin()
    {
        player.GetComponent<MyPlayer>().enabled = false;
        Btn.SetActive(true);
        ring.SetActive(true);
        play.SetActive(false);
        exit.SetActive(true);
        f = 0f;
        dificulty += 1;
        start = true;
    }

    public void Exit()
    {
        player.GetComponent<MyPlayer>().enabled = true;
        Btn.SetActive(false);
        ring.SetActive(false);
        exit.SetActive(false);
        dificulty = 0;
        start = false;

    }


    void Start()
    {
        locked = true;
        sound = GameObject.Find("Game QTE").GetComponent<SoundSource>();
        player = GameObject.Find("Player");
    }


    void Update()
    {

        if (dificulty == 1)
        {
            Btn.GetComponent<RectTransform>().anchoredPosition = new Vector2(70, -124);
            level = 0.4f;
        }

        if (dificulty == 2)
        {
            Btn.GetComponent<RectTransform>().anchoredPosition = new Vector2(-200, 100);
            level = 0.8f;
        }

        if (dificulty == 3)
        {
            Btn.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -200);
            level = 1.2f;
        }

        if (dificulty == 4)
        {
            Btn.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            level = 1.6f;
        }

        if (dificulty == 5)
        {
            Btn.GetComponent<RectTransform>().anchoredPosition = new Vector2(-89, 300);
            level = 2f;
        }

        if (dificulty == 6)//win
        {
            Exit();
            locked = false;
            //GetComponent<QTE>
        }

        if (loss == true)
        {
            player.GetComponent<MyPlayer>().enabled = true;
            sound.PlaySound();
            dificulty = 0f;
            Awin.Play();
            start = false;
            f = 0f;
            dificulty = 0f;
            Debug.Log("loss");
            loss = false;
        }

        if (f >= 1) //loss
        {
            //play sound deactivate
            player.GetComponent<MyPlayer>().enabled = true;
            Btn.SetActive(false);
            ring.SetActive(false);
            sound.PlaySound();
            start = false;
            dificulty = 0f;
            Debug.Log("loss");
            //loss = true;
            f = 0f;
        }
        if (f == 1)
        {
            GetComponent<SoundSource>().PlaySound();
        }

        if (start == true)
        {
            f += Time.deltaTime * level;
        }



        ring.GetComponent<Image>().fillAmount = f;


    }


}
