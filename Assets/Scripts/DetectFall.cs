using UnityEngine;
using System.Collections;

public class DetectFall : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other) {
		
		// if it is the ball
		if (other.gameObject.tag == "Ball") {
			GameInfo.LoseLife();	// subtract one life of the player
			GameObject.Find ("GameManager").SendMessage("SetPadAndBall");	// reset position
			other.gameObject.SendMessage("SetVariables");	// return speed to normal
		}
		// remove other objects to save memory
		else {
			Destroy(other.gameObject);
		}
	}
}
