using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jaakko : MonoBehaviour

{

    public GameObject Enemy;
    public Transform Player;
    private float Speed;
    private float Gravity = -9.81f;
    private float timeLooking;
    private bool isChasing;

    [SerializeField]
    private Transform Groundcheck;
    private float groundDistance = 0.1f;
    [SerializeField]
    private LayerMask groundMask;
    Vector3 Velocity;
    bool isGrounded;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        transform.LookAt(Player);

        //transform.position.y = 0f;

        isGrounded = Physics.CheckSphere(Groundcheck.position, groundDistance, groundMask);
        if(isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }
        Velocity.y += Gravity * Time.deltaTime;


        Vector3 screenPoint = Player.GetChild(0).GetComponent<Camera>().WorldToViewportPoint(gameObject.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        if (onScreen && !isChasing) 
        {
            Speed = 0f;
            animator.SetBool("Looking", true);

            //Chase
            timeLooking += Time.deltaTime;
            if (timeLooking >= 3f)
            {
                isChasing = true;
                animator.SetBool("Charge", true);
                Speed = 10f;
            }
        }
        else if(!onScreen && !isChasing)
        {
            Speed = 1f;
            animator.SetBool("Looking", false);
            timeLooking = 0f;
        }


        Enemy.transform.position = new Vector3(transform.position.x, Velocity.y, transform.position.z);
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.position, step);


    }





}
