using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class simonSays : MonoBehaviour
{
    public GameObject button1;
    public Texture button1_on;
    public Texture button1_off;
    public GameObject button2;
    public Texture button2_on;
    public Texture button2_off;
    public GameObject button3;
    public Texture button3_on;
    public Texture button3_off;
    public GameObject button4;
    public Texture button4_on;
    public Texture button4_off;
    public GameObject button5;
    public Texture button5_on;
    public Texture button5_off;
    public int gameLength = 4;
    public AudioSource speaker;
    public float volume = 0.5f;
    public AudioClip beep;
    public AudioClip win_sound;
    public AudioClip loose_sound;

    private int gameStage = 1;
    private int flashSeq = 0;
    private bool flashActive = false;
    private bool flashGo = false;
    private bool allowInput = false;
    private bool gameOver = false;
    static float lastClickTime = -999;

    List<string> sequence = new List<string>();
    List<string> buffer = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        button1.GetComponent<Renderer>().material.mainTexture = button1_off;
        button2.GetComponent<Renderer>().material.mainTexture = button2_off;
        button3.GetComponent<Renderer>().material.mainTexture = button3_off;
        button4.GetComponent<Renderer>().material.mainTexture = button4_off;
        button5.GetComponent<Renderer>().material.mainTexture = button5_off;

        // Naming System
        button1.name = "button1";
        button2.name = "button2";
        button3.name = "button3";
        button4.name = "button4";
        button5.name = "button5";

        generateSequence();
        flashGo = true;
    }

    // Update is called once per frame

    void Update()
    {
        if (gameOver == false)
        {
            displaySequence();
            allowInput = true;
            string buttonInput = "";

            if (allowInput == true)
            {
                int i = 0;
                buttonInput = getInput();

                if (buttonInput != "")
                {
                    if (Time.time - lastClickTime < 1.5f)
                    {
                        Debug.Log("Too Soon");
                        return;
                    }
                    lastClickTime = Time.time;
                    allowInput = false;
                    StartCoroutine(flashButton(buttonInput, 0f));
                    buffer.Add(buttonInput);

                    foreach (string press in buffer)
                    {
                        if (press == sequence[i])
                        {
                            Debug.Log("Correct, the input was " + press + " and the seqence was " + sequence[i]);
                            i++;
                        }
                        else
                        {
                            loose();
                        }
                    }
                    if (i == gameStage)
                    {
                        buffer.Clear();
                        gameStage++;
                        displaySequence();
                        Debug.Log("Stage Cleared");
                        flashGo = true;
                        if (gameStage == 6)
                        {
                            win();
                        }

                    }
                }
            }
        }
    }

    string getInput()
    {
        string buttonClicked = "";
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                buttonClicked =  hit.collider.gameObject.name;
            }
        }
        return buttonClicked;
    }

    void win()
    {
        gameOver = true;
        Debug.Log("you win!");
        speaker.PlayOneShot(win_sound, 2f);
    }

    void loose()
    {
        gameOver = true;
        Debug.Log("You Loose :(");
        speaker.PlayOneShot(loose_sound, volume);
    }

    void displaySequence()
    {
        if (flashSeq <= gameStage -1 && flashActive == false && flashGo == true)
        {
            StartCoroutine(flashButton(sequence[flashSeq], 1f));
            flashSeq++;
            if (flashSeq == gameStage)
            {
                flashGo = false;
                flashSeq = 0;
            }
        }
    }

    IEnumerator sleep()
    {
        yield return new WaitForSeconds(1f);
    }

    void generateSequence()
    {

        for (int i = 0; i <= gameLength; i++)
        {
            int randValue = Random.Range(0, gameLength);
            if (randValue == 0)
            {
                sequence.Add("button1");
            }
            if (randValue == 1)
            {
                sequence.Add("button2");
            }
            if (randValue == 2)
            {
                sequence.Add("button3");
            }
            if (randValue == 3)
            {
                sequence.Add("button4");
            }
            if (randValue == 4)
            {
                sequence.Add("button5");
            }
        }
        foreach(var x in sequence)
        {
            Debug.Log("Sequence: " + x.ToString());
        }
    }

    IEnumerator flashButton(string button, float delay)
    {
        flashActive = true;
        yield return new WaitForSeconds(delay);
        if (button == "button1")
        {
            button1.GetComponent<Renderer>().material.mainTexture = button1_on;
            speaker.PlayOneShot(beep, volume);
            yield return new WaitForSeconds(1f);
            button1.GetComponent<Renderer>().material.mainTexture = button1_off;
            yield return new WaitForSeconds(1f);
        }
        if (button == "button2")
        {
            button2.GetComponent<Renderer>().material.mainTexture = button2_on;
            speaker.PlayOneShot(beep, volume);
            yield return new WaitForSeconds(1f);
            button2.GetComponent<Renderer>().material.mainTexture = button2_off;
            yield return new WaitForSeconds(1f);
        }
        if (button == "button3")
        {
            button3.GetComponent<Renderer>().material.mainTexture = button3_on;
            speaker.PlayOneShot(beep, volume);
            yield return new WaitForSeconds(1f);
            button3.GetComponent<Renderer>().material.mainTexture = button3_off;
            yield return new WaitForSeconds(1f);
        }
        if (button == "button4")
        {
            button4.GetComponent<Renderer>().material.mainTexture = button4_on;
            speaker.PlayOneShot(beep, volume);
            yield return new WaitForSeconds(1f);
            button4.GetComponent<Renderer>().material.mainTexture = button4_off;
            yield return new WaitForSeconds(1f);
        }
        if (button == "button5")
        {
            button5.GetComponent<Renderer>().material.mainTexture = button5_on;
            speaker.PlayOneShot(beep, volume);
            yield return new WaitForSeconds(1f);
            button5.GetComponent<Renderer>().material.mainTexture = button5_off;
            yield return new WaitForSeconds(1f);
        }
        flashActive = false;
    }

}


