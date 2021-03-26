using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jaakko : MonoBehaviour

{
    
    public GameObject Enemy;
    public Transform Player;
    private float Speed;
    private bool isChasing;
    public GameObject origin;
    private float Patience;
    private float Timer;


    public AudioSource jaakkoChase;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        Patience = gameObject.GetComponent<RNG>().RandomInt();
    }

    void Update()
    {

        Timer += Time.deltaTime;
        if (Timer >= 1)
        {
            Patience = gameObject.GetComponent<RNG>().RandomInt();
            Timer = 0;
        }

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        transform.LookAt(new Vector3(Player.position.x, 0f, Player.position.z));



        Vector3 screenPoint = Player.GetChild(0).GetComponent<Camera>().WorldToViewportPoint(origin.transform.position);
        Vector3 screenPointBottom = Player.GetChild(0).GetComponent<Camera>().WorldToViewportPoint(gameObject.transform.position);
        bool onScreen = (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)||
                        (screenPointBottom.z > 0 && screenPointBottom.x > 0 && screenPointBottom.x < 1 && screenPointBottom.y > 0 && screenPointBottom.y < 1);

        if (onScreen && !isChasing) 
        {
            Speed = 0f;
            animator.SetBool("Looking", true);

            

            if (Patience == 5)
            {
                isChasing = true;
                animator.SetBool("Charge", true);
                Speed = 15f;
                jaakkoChase.Play();
            }
        }
        else if(!onScreen && !isChasing)
        {
            Speed = 1f;
            animator.SetBool("Looking", false);
        }


        Enemy.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.position, step);


    }


}
