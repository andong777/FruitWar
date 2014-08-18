using UnityEngine;
using System.Collections;

public class BallFly : MonoBehaviour {
	
	private const float normalSpeed = 6f;
	
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
	
	void Start () {
		SetVariables ();
		Random.seed = System.DateTime.Now.Millisecond;
	}
	
	void Update () {
		// Control the ball.
		if (Input.GetButtonUp ("Fire1") && !GameInfo.Released) {
			Debug.Log("Fire");
			// choose a random direction.			
			float dirX = Random.Range(-0.8f, 0.8f);
			float dirY = Mathf.Sqrt(1 - dirX * dirX);
			Vector2 direct = new Vector2(dirX, dirY);
			
			rigidbody2D.velocity = direct * normalSpeed;
			
			// mark as released
			GameInfo.Released = true;
		}
	}
	
	// this method is to avoid the situations below:
	// 1. where ball flies too slow or too fast after collision
	// 2. where ball flies horizontally
	void FixedUpdate () {
		if (GameInfo.Released) {
			Vector3 velocity = rigidbody2D.velocity;
		
			// to solve problem 1
			float speed = velocity.sqrMagnitude;
			if (speed < speedMinThreshold) {
				velocity.Normalize();
				rigidbody2D.velocity = velocity * speedMinValue;
			}
			else if(speed > speedMaxThreshold) {
				velocity.Normalize();
				rigidbody2D.velocity = velocity * speedMaxValue;
			}
			
			// to solve problem 2
			float angle = Mathf.Atan(velocity.y / velocity.x) * Mathf.Rad2Deg;
			if (Mathf.Abs(angle) < angleThreshold) {
				Debug.Log("Angle amendment takes effect: "+angle);
				float amend = Mathf.Sign(velocity.y) * multifyValue;
				rigidbody2D.velocity = velocity + new Vector3(0, amend, 0);
			}
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Brick") {
			other.rigidbody.isKinematic = false;	// let it fall
			other.collider.isTrigger = true;	// let it be transparent
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		// Debug.Log("fireball working");
		if (other.gameObject.tag == "Brick") {
			other.rigidbody2D.isKinematic = false;	// let it fall
			other.collider2D.isTrigger = true;	// let it be transparent
		}
	}
	
	void SetVariables () {	
		Debug.Log("speed reset");
		// recover previous speed
		rigidbody2D.velocity = rigidbody2D.velocity.normalized * normalSpeed;
		
		// recover thresholds and values
		speedMinValue = normalSpeed - 1;
		speedMinThreshold = speedMinValue * speedMinValue;
		speedMaxValue = normalSpeed + 1;
		speedMaxThreshold = speedMaxValue * speedMaxValue;
		angleThreshold = 10f;
		multifyValue = 3f;
	}
	
	void SetSpeedByRatio (float ratio) {
		Debug.Log("set speed by "+ratio);

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
	
	void MakeFireBall (float time){
		// find absolute value of border, choose right and top because they are positive
		float absX = GameObject.Find ("RightConverter").transform.position.x;
		float absY = GameObject.Find ("TopConverter").transform.position.y;
		float ballX = transform.position.x + collider2D.bounds.size.x;
		float ballY = transform.position.y + collider2D.bounds.size.y;
		// if ball inside converters, change it to trigger, else do nothing
		if(Mathf.Abs(ballX) < absX && Mathf.Abs (ballY) < absY){	
			Debug.Log("Inside converters, to trigger");
			collider2D.isTrigger = true;
			Invoke ("LoseFireBall", time);
		}
	}
	
	void LoseFireBall (){
		collider2D.isTrigger = false;
	}
	
}
