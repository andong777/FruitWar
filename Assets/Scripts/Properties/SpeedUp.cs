﻿using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour {

	float ratio = 1.5f;
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			GameObject.Find("Ball").SendMessage("SetSpeedByRatio", ratio);
		}
	}
}