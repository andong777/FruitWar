using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			GameInfo.GainLife();
		}
	}
}
