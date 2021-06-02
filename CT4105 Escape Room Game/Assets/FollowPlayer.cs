using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField]
    private GameObject player;

    bool movementEnabled, timerActive, coolDownActive;
    float timer, cooldownTimer;

    void Update(){
        if (movementEnabled){
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
        else{
            agent.isStopped = true;
        }

        if (timerActive){
            timer -= Time.deltaTime;
        }

        if (coolDownActive){
            cooldownTimer -= Time.deltaTime;
        }

        if (cooldownTimer <= 0f){
            cooldownTimer = 0.5f;
            coolDownActive = false;
            timerActive = true;
            movementEnabled = true;
            gameObject.GetComponent<Animator>().SetBool("Left", !gameObject.GetComponent<Animator>().GetBool("Left"));
            gameObject.GetComponent<Animator>().SetBool("Right", !gameObject.GetComponent<Animator>().GetBool("Right"));
        }

        if (timer <= 0){
            timer = 0.5f;
            timerActive = false;
            coolDownActive = true;
            movementEnabled = false;
        }
    }
}
