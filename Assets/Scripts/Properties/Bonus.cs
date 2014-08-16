using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

	private int bonusByBrick = 3;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			GameInfo.AddScoreByBrick(bonusByBrick);
		}
	}
}
