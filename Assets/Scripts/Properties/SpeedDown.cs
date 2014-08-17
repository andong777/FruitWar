using UnityEngine;
using System.Collections;

public class SpeedDown : MonoBehaviour {
	
	float ratio = 0.5f;
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			Debug.Log("get speed down");
			GameObject.Find("Ball").SendMessage("SetSpeedByRatio", ratio);
		}
	}
}