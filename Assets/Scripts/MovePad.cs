using UnityEngine;
using System.Collections;

public class MovePad : MonoBehaviour {

	public float speed = 20f;

	private GameObject ball = null;
	private bool released = false;

	void Awake() {

		ball = GameObject.Find ("Ball");
	}

	void Start () {
		Vector3 tempPos = transform.position;
		tempPos.y += ball.renderer.bounds.size.y /2 + renderer.bounds.size.y / 2;
		ball.transform.position = tempPos;
	}

	void Update () {

		// Move the pad horizontally.
		float input = Input.GetAxis ("Horizontal");
		float offset = speed * input * Time.deltaTime;
		float dest = transform.position.x + offset;
		
		float z = transform.position.z - Camera.main.transform.position.z;
		float fix = renderer.bounds.size.x / 2;
		float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, z)).x + fix;
		float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, z)).x - fix;
//		Debug.Log ("left: "+leftBorder+" right: "+rightBorder);
		transform.position = new Vector3(Mathf.Clamp(dest, leftBorder, rightBorder), 
								transform.position.y, transform.position.z);
//		Debug.Log (transform.position.x+" "+transform.position.y+" "+transform.position.z);
		if(!released){
			float up = ball.renderer.bounds.size.y /2 + renderer.bounds.size.y / 2;
			Debug.Log(up);
			ball.transform.position = transform.position + new Vector3(0, up, 0);
		}
	}

	public bool Released { 
		get{ return released;}
		set{ released = value;}
	}

}
