using UnityEngine;
using System.Collections;

public class MovePad : MonoBehaviour {

	public float speed = 20f;

	private GameObject ball = null;

	void Awake() {
		ball = GameObject.Find ("Ball");
	}

	void Update () {
		// Move the pad horizontally.
		float input = Input.GetAxis ("Horizontal");
		Vector3 offset = new Vector3(speed * input, 0, 0);		
		rigidbody2D.velocity = offset;
		
		// if the ball unreleased, move it also
		if(!GameInfo.Released) {
			float up = gameObject.collider2D.bounds.size.y / 2 + ball.collider2D.bounds.size.y / 2;
			ball.transform.position = transform.position + new Vector3(0, up, 0);
		}
		
	}
	
	void OnCollisionEnter2D (Collision2D other) {
		// if it is the released ball, add effect on the ball
		if(other.gameObject.tag == "Ball" && GameInfo.Released){
			other.rigidbody.velocity = other.rigidbody.velocity / 2 + rigidbody2D.velocity / 3;			
		}
		
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		// if it is a property, eat it
		if(other.gameObject.tag == "Property"){
			Debug.Log("pad gets a property");
			Destroy (other.gameObject, 0.5f);
		}
		// if it is a brick, do KillBrick
		else if(other.gameObject.tag == "Brick"){
			Destroy(other.gameObject);
			GameInfo.KillBrick();
		}
	}
}
