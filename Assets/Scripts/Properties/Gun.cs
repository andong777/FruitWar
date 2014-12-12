using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){

			Debug.Log("get gun");
            GameUIHelper.Instance.DrawHint("获得弹药");
			other.SendMessage("LoadBullets");
		}
	}
}
