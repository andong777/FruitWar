using UnityEngine;
using System.Collections;

public class BallFly : MonoBehaviour {
	
	// if speed smaller or greater than speed threshold, set the speed to value
	private float speedMinThreshold;
	private float speedMinValue;
	private float speedMaxThreshold;
	private float speedMaxValue;
	// if velocity angle smaller than angle threshold, add speed at y axis by value
	private float angleThreshold;
	private float multifyValue;
	
	// speed will return to normal after resetTime
	private const float resetTime = 3f;
	// mark the scale of speed change
	private float ratio = 1f;
	
	void Start () {
		SetVariables ();
	}
	
	// this method is to avoid the situations below:
	// 1. where ball flies too slow or too fast after collision
	// 2. where ball flies horizontally
	void FixedUpdate () {
//		Debug.Log(rigidbody2D.velocity.sqrMagnitude);
		Vector3 velocity = rigidbody2D.velocity;
		// to solve problem 1
		float speed = velocity.sqrMagnitude;
		if (GameInfo.Released) {
			if (speed < speedMinThreshold) {
				velocity.Normalize();
				rigidbody2D.velocity = velocity * speedMinValue;
			}
			else if(speed > speedMaxThreshold) {
				velocity.Normalize();
				rigidbody2D.velocity = velocity * speedMaxValue;
			}
		}
		// to solve problem 2
		float angle = Mathf.Atan(velocity.y / velocity.x) * Mathf.Rad2Deg;
		if (Mathf.Abs(angle) < angleThreshold) {
			Debug.Log("Angle amendment takes effect: "+angle);
			float amend = Mathf.Sign(velocity.y) * multifyValue;
			rigidbody2D.velocity = velocity + new Vector3(0, amend, 0);
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Brick") {
			// Destroy (other.gameObject);
			// GameInfo.killBrick();
			other.rigidbody.isKinematic = false;	// let it fall
			other.collider.isTrigger = true;	// let it be transparent
		}
	}
	
	void SetVariables () {	
		Debug.Log("speed reset");
		// recover previous speed
		rigidbody2D.velocity = rigidbody2D.velocity / ratio;
		
		// recover thresholds and values
		speedMinThreshold = 80f;
		speedMinValue = 9f;
		speedMaxThreshold = 100f;
		speedMaxValue = 10f;
		angleThreshold = 10f;
		multifyValue = 3f;
	}
	
	void SetSpeedByRatio (float ratio) {
		Debug.Log("set speed by "+ratio);
		
		// mark down this number for later recovery
		this.ratio = ratio;
		// change the speed
		rigidbody2D.velocity = rigidbody2D.velocity * ratio;
		// change thresholds and values to avoid speed restriction
		speedMinThreshold *= ratio * ratio;
		speedMinValue *= ratio;
		speedMaxThreshold *= ratio * ratio;
		speedMaxValue *= ratio;
		
		// call reset after some delay
		Invoke("SetVariables", resetTime);
	}
	
}
