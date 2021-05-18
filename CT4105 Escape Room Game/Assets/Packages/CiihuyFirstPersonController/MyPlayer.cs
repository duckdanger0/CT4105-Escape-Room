using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MyPlayer : MonoBehaviour {
	public float speed;
	public MyJoystick joystick;

	void FixedUpdate () {
		//Vector3 movement = new Vector3 (joystick.Horizontal () * Time.deltaTime, 0.0f, joystick.Vertical() * Time.deltaTime);
		//rb.AddForce (movement * speed);
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * (speed * joystick.Vertical());
        this.gameObject.transform.position += this.gameObject.transform.right * Time.deltaTime * (speed * joystick.Horizontal());
    }
}