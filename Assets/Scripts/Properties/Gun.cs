using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){

			Debug.Log("get gun");
			other.gameObject.SendMessage("LoadBullets");
		}
	}
}
