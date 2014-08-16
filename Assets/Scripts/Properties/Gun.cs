using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			// TODO
			// need bullet prefab which is trigger and add "DetectFall" to top wall
		}
	}
}
