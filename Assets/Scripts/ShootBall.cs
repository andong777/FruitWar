using UnityEngine;
using System.Collections;

public class ShootBall : MonoBehaviour {
		
	private float normalBallSpeed = 10f;
	
	private GameObject ball = null;
	
	void Awake () {
		ball = GameObject.Find("Ball");
	}
	
	// Use this for initialization
	void Start () {
		Random.seed = System.DateTime.Now.Millisecond;
	}
	
	// Update is called once per frame
	void Update () {
		// Control the ball.
		if (Input.GetButtonDown ("Fire1") && !GameInfo.Released) {
			Debug.Log("Fire");
			// choose a random direction.			
			float dirX = Random.value;
			float dirY = Mathf.Sqrt(1 - dirX * dirX);
			Vector2 direct = new Vector2(dirX, dirY);
			
			ball.rigidbody2D.velocity = direct * normalBallSpeed;
			
			// mark as released
			GameInfo.Released = true;
		}
	}

}
