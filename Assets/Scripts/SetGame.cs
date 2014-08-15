using UnityEngine;
using System.Collections;

public class SetGame: MonoBehaviour {

	// Collider components
	public Transform leftWall;
	public Transform rightWall;
	public Transform topWall;
	public Transform bottomWall;

	// set pad and ball to original position
	private Transform pad = null;
	private Transform ball = null;
	
	// record some values
	private float leftPos;
	private float rightPos;
	private float topPos;
	private float bottomPos;
	
	void Awake () {
		pad = GameObject.Find("Pad").transform;
		ball = GameObject.Find("Ball").transform;
	}

	// Use this for initialization
	void Start () {
		// get the border
		leftPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
		rightPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
		topPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
		bottomPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
		// set walls
		leftWall.position = new Vector3(leftPos - leftWall.gameObject.collider2D.bounds.size.x / 2, 0, 0);
		rightWall.position = new Vector3(rightPos + rightWall.gameObject.collider2D.bounds.size.x / 2, 0, 0);
		topWall.position = new Vector3(0, topPos + topWall.gameObject.collider2D.bounds.size.y / 2, 0);
		bottomWall.position = new Vector3(0, bottomPos - bottomWall.gameObject.collider2D.bounds.size.y / 2, 0);
		
		// set the pad and the ball
		SetPadAndBall();
	}
	
	void SetPadAndBall() {
		// set pad position
		pad.position = new Vector3(0, bottomPos + 1, 0);
		// set ball position
		ball.position = pad.position + new Vector3(0, ball.gameObject.collider2D.bounds.size.y / 2, 0);
		// mark the ball as unreleased
		GameInfo.Released = false;
	}

}
