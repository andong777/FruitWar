using UnityEngine;
using System.Collections;

public class DetectFall : MonoBehaviour {
	
	public bool bottom;
	
	void OnTriggerEnter2D (Collider2D other) {
		
		// if it is the ball
		if (bottom && other.gameObject.tag == "Ball") {
			GameInfo.LoseLife();	// subtract one life of the player
			other.gameObject.SendMessage("SetVariables");	// recover normal thresholds and values
			GameObject.Find ("GameManager").SendMessage("SetPadAndBall");	// reset position, zero speed*
		}
		// remove other objects to save memory
		else {
			Debug.Log("catch something");
			if(other.gameObject.tag == "Brick"){
				GameInfo.LoseBrick();	// to help game manager count brick number
			}
			Destroy(other.gameObject);
		}
	}
}
