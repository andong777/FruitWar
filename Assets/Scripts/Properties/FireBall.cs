using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	private float time = 40f;

	private GameObject ball;
	private GameObject[] converters;

	void Awake () {
		ball = GameObject.Find("Ball");
		converters = GameObject.FindGameObjectsWithTag("Converter");
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			Debug.Log("get fireball");
			// set ball to trigger		
			ball.SendMessage("MakeFireBall", time);
			// let converters work
			foreach(var c in converters){
				c.SendMessage("TakeEffect", time);
			}
		}
	}

}
