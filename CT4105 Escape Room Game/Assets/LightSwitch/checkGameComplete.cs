using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkGameComplete : MonoBehaviour
{
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject switch4;
    public GameObject switch5;
    public GameObject switch6;




    

    // Update is called once per frame
    void Update()
    {
        if (switch1.GetComponent<Switch>().switchValue)
        {
            if (switch2.GetComponent<Switch>().switchValue)
            {
                if (switch3.GetComponent<Switch>().switchValue)
                {
                    if (switch4.GetComponent<Switch>().switchValue)
                    {
                        if (switch5.GetComponent<Switch>().switchValue)
                        {
                            if (switch6.GetComponent<Switch>().switchValue)
                            {
                                GlobalControl.Instance.score =+100;
                                SceneManager.LoadScene("Floor 2 - Arcade");
                            }
                        }
                    }
                }
            }
        }
    }
}
