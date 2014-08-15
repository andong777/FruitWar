using UnityEngine;
using System.Collections;

public class DetectFall : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other) {
		// if it is property, remove it
		if (other.gameObject.tag == "Property") {
			Destroy(other.gameObject);
		}
		// if it is the ball, subtract one life of the player and reset
		else if (other.gameObject.tag == "Ball") {
			GameInfo.loseLife();
			GameObject.Find ("GameManager").SendMessage("SetPadAndBall");
		}
	}
}
