using UnityEngine;
using System.Collections;

public class Enlarge : MonoBehaviour {

	float ratio = 1.2f;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			Vector3 scale = other.transform.localScale;
			scale.x = ratio * scale.x;
			other.transform.localScale = scale;
		}
	}
}