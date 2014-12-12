using UnityEngine;
using System.Collections;

public class Poison : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			Debug.Log("get poison");
            Manager.LoseLife();	// subtract one life of the player
            SetGame.Instance.SetPadAndBall();   // reset position, zero speed
		}
	}
}
