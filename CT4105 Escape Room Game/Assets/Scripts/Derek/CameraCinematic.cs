using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCinematic : MonoBehaviour {

    [SerializeField]
    private Cinematic rail;
    [SerializeField]
    private Animator derekAnim;

    private int currentSegment = 1;
    private float transition;
    private bool isCompleted;

    public PlayMode mode;
    public float speed = .5f;
    public bool isReversed;
    public bool isLooping;
    public bool isToAndFro;

    float timer, cooldownTimer;
    bool timerActive, coolDownActive, movementEnabled;

    void Start(){
        timer = .5f;
        cooldownTimer = .5f;
        timerActive = true;
        movementEnabled = true;
        coolDownActive = false;
        derekAnim.SetBool("Left", false);
        derekAnim.SetBool("Right", true);
    }

    private void Update() {
        if (!rail) {
            return;
        }
        if (!isCompleted) {
            Play(!isReversed);
        }

    }

    private void Play(bool forward = true) {
        if (movementEnabled){
            float magnitude = (rail.nodes[currentSegment + 1].position - rail.nodes[currentSegment].position).magnitude;
            float cameraSpeed = (Time.deltaTime * 1 / magnitude) * speed;
            transition += (forward) ? cameraSpeed : -cameraSpeed;

            if (transition > 1) {
                transition = 0;
                currentSegment++;

                if (currentSegment == rail.nodes.Length - 1) {
                    if (isLooping) {
                        if (isToAndFro) {
                            transition = 1;
                            currentSegment = rail.nodes.Length - 2;
                            isReversed = !isReversed;
                        }
                        currentSegment = 1;
                    }
                    else {
                        isCompleted = true;
                        return;
                    }
                }
            }
            else if (transition < 0) {
                transition = 1;
                currentSegment--;

                if (currentSegment == -1) {

                    if (isLooping) {

                        if (isToAndFro) {
                            transition = 1;
                            currentSegment = 1;
                            isReversed = !isReversed;
                        }
                        currentSegment = rail.nodes.Length - 2;
                    }
                    else {
                        isCompleted = true;
                        return;
                    }
                }
            }
            transform.position = rail.PosOnRail(currentSegment, transition, mode);
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

            derekAnim.SetBool("Left", !derekAnim.GetBool("Left"));
            derekAnim.SetBool("Right", !derekAnim.GetBool("Right"));
        }

        if (timer <= 0){
            timer = .5f;
            timerActive = false;
            coolDownActive = true;
            movementEnabled = false;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, rail.CurrentSegmentAngle(currentSegment), Time.deltaTime * 5f);

    }
}
