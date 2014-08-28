using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

	private int bonusByBrick = 5;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			Debug.Log("get bonus");
			Manager.AddScoreByBrick(bonusByBrick);
		}
	}
}
