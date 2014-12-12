using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	private float time = 3f;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pad"){
			Debug.Log("get fireball");
            GameUIHelper.Instance.DrawProperty(GetComponent<SpriteRenderer>().sprite);
            GameUIHelper.Instance.DrawHint("获得隐身药水");
            // set ball to fireball
            GameObject.Find("Ball").SendMessage("MakeFireBall", time);
		}
	}
}
