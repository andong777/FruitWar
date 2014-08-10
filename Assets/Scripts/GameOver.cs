using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("Something is falling!");
		// check if it is ball or property.
		if (other.gameObject.tag == "Ball") {
			Debug.Log("You lose one life.");
		} else {
		
		}
		Destroy (other.gameObject);
		
	}
}
