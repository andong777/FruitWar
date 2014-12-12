using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour {

	float ratio = 1.2f;
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			Debug.Log("get speed up");
            GameUIHelper.Instance.DrawHint("加速");
            GameUIHelper.Instance.DrawProperty(GetComponent<SpriteRenderer>().sprite);
			GameObject.Find("Ball").SendMessage("SetSpeedByRatio", ratio);
		}
	}
}