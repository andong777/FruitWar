using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.tag == "Brick"){
			Destroy(other.gameObject);			
			GameInfo.KillBrick();			
			Destroy(gameObject);	// destroy itself also
		}
	}
}
