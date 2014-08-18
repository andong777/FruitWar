using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	private float time = 3f;

	private GameObject ball;

	void Awake () {
		ball = GameObject.Find("Ball");
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			Debug.Log("get fireball");
			// set ball to fireball
			ball.SendMessage("MakeFireBall", time);
			
		}
	}
}
