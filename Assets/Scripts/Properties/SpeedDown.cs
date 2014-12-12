using UnityEngine;
using System.Collections;

public class SpeedDown : MonoBehaviour {
	
	float ratio = 0.8f;
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			Debug.Log("get speed down");
            GameUIHelper.Instance.DrawHint("减速");
            GameUIHelper.Instance.DrawProperty(GetComponent<SpriteRenderer>().sprite);
			GameObject.Find("Ball").SendMessage("SetSpeedByRatio", ratio);

		}
	}
}