using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jaakko : MonoBehaviour

{

    public GameObject Enemy;
    public Transform Player;
    public float Speed;

    void Update()
    {
        Vector3 screenPoint = Player.GetChild(0).GetComponent<Camera>().WorldToViewportPoint(gameObject.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        if (onScreen) {
            Speed = 0f;
        }
        else {
            Speed = 5f;
        }

        Enemy.transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.position, step);


    }
}
