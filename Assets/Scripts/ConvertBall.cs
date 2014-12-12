using UnityEngine;
using System.Collections;

public class ConvertBall : MonoBehaviour {
	
	public static bool work = false;
	
	void OnTriggerEnter2D (Collider2D other) {
		if(work && other.gameObject.tag == "Ball"){
			Debug.Log("no trigger");
			other.isTrigger = false;
		}
	}
	
	void OnCollisionExit2D (Collision2D other) {
		if(work && other.gameObject.tag == "Ball"){
			Debug.Log("is trigger");
			other.collider.isTrigger = true;
		}		
	}

}
