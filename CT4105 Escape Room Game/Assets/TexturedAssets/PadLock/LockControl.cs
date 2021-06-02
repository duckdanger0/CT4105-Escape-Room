using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    private bool isOpened;

    public GameObject wheel1, wheel2, wheel3, wheel4, betty;

    private void Start()
    {
        result = new int[]{0,0,0,0};
        correctCombination = new int[] {4,2,0,9};
        isOpened = false;
    }

    void Update(){
        result[0] = wheel1.GetComponent<Rotate>().numberShown;
        result[1] = wheel2.GetComponent<Rotate>().numberShown;
        result[2] = wheel3.GetComponent<Rotate>().numberShown;
        result[3] = wheel4.GetComponent<Rotate>().numberShown;
    }

    public void CheckResults()
    {
            if (result[0] == correctCombination[0] && result[1] == correctCombination[1]
            && result[2] == correctCombination[2] && result[3] == correctCombination[3] && !isOpened)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            isOpened = true;

            StartCoroutine(SwapScene());
        }
    }

    private IEnumerator SwapScene(){
        betty.SetActive(false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
    }
}
