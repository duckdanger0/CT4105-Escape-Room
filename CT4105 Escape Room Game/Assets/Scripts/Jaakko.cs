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
        Enemy.transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.position, step);
    }

    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.gameObject.tag == "Looking")
        {
            Speed = 0;
        }
    }

    void OnTriggerExit(Collider Coll)
    {
        if (Coll.gameObject.tag == "Looking")
        {
            transform.LookAt(Player);
            Speed = 5f;
        }
    }
}
