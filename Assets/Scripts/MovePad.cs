using UnityEngine;
using System.Collections;

public class MovePad : MonoBehaviour {

	public float speed = 10f;

	private Transform ball = null;

	void Awake() {
		ball = GameObject.Find ("Ball").transform;
	}

	void Update () {
        // Move the pad horizontally.
#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_METRO
        float input = Input.GetAxis ("Horizontal");
#elif UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8
        float input = -1 * Input.acceleration.y;    // because it's landscape
#else
        float input = 0f;   // not supported yet
#endif
        Vector3 offset = new Vector3(speed * input, 0, 0);
        rigidbody2D.velocity = offset;
		
		// if the ball unreleased, move it also
		if(!Manager.Released) {
			float up = gameObject.collider2D.bounds.size.y / 2 + ball.collider2D.bounds.size.y / 2;
			ball.position = transform.position + new Vector3(0, up, 0);
		}
		
	}
	
	void OnCollisionEnter2D (Collision2D other) {
		// if it is the released ball, add effect on the ball
		if(other.gameObject.tag == "Ball" && Manager.Released){
			other.rigidbody.velocity = other.rigidbody.velocity / 2 + rigidbody2D.velocity / 3;			
		}
		
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		// if it is a property, eat it
		if(other.gameObject.tag == "Property"){
			Debug.Log("pad gets a property");
            if(other.audio!=null)
                other.audio.Play();
            // let bottom wall recycle it
		}
		// if it is a brick, do KillBrick
		else if(other.gameObject.tag == "FallBrick"){
            other.audio.Play();
			Destroy(other.gameObject);
			Manager.KillBrick();
		}
	}

    void Reset()
    {
        transform.localScale = Vector3.one; // resize pad
    }
}
