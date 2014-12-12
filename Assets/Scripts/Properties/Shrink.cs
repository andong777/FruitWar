using UnityEngine;
using System.Collections;

public class Shrink : MonoBehaviour {
	
	float ratio = 0.8f;
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			Debug.Log("get shrink");
            GameUIHelper.Instance.DrawHint("缩短");
			Vector3 scale = other.transform.localScale;
			scale.x = ratio * scale.x;
			other.transform.localScale = scale;
		}
	}
}