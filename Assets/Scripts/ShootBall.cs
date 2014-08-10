using UnityEngine;
using System.Collections;

public class ShootBall : MonoBehaviour {

	private Transform pad = null;		
	private float normalBallSpeed = 10f;
	private MovePad releaseChecker = null;

	void Awake() {
		pad = GameObject.Find ("Pad").transform;
		releaseChecker = pad.GetComponent<MovePad> ();

		Debug.Log (Screen.width + " " + Screen.height);
		
		Random.seed = System.DateTime.Now.Millisecond;
 	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		// Control the ball.
		if (Input.GetButtonDown ("Fire1") && !releaseChecker.Released) {
			Debug.Log("Fire");
			// choose a random direction.
			
			float directX = Random.value;
			float directY = Mathf.Sqrt(1 - directX * directX);
			Vector2 direct = new Vector2(directX, directY);
			
			rigidbody2D.velocity = direct * normalBallSpeed;
			
			// set to true.
			releaseChecker.Released = true;
		}
	}

	void FixedUpdate() {

		if (releaseChecker.Released) {
//			Debug.Log (gameObject.transform.position.x +" "+ gameObject.transform.position.y);
			// Check if the ball goes out of screen.
			Vector3 newPos = Camera.main.WorldToScreenPoint(transform.position);
			
			if (newPos.x <= 0 || newPos.x >= Screen.width) {
				float speedX = -1 * rigidbody2D.velocity.x;
				rigidbody2D.velocity = new Vector2(speedX, rigidbody2D.velocity.y);
			}
			if (newPos.y >= Screen.height) {
				float speedY = -1 * rigidbody2D.velocity.y;
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, speedY);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log ("Collision is happening");
		if (other.gameObject.tag != "Player") {
			Destroy (other.gameObject);
		}
	}

}
