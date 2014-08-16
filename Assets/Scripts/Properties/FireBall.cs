using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			// TODO
			// plan to set all bricks to trigger and later on return them to collider
		}
	}
}
