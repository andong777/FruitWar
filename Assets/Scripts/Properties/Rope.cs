using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {

	private float time = 3f;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			Debug.Log("get rope");
			GameObject.Find ("Pad").SendMessage("MakeRope", time);
		}
	}
}
