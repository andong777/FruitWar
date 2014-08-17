using UnityEngine;
using System.Collections;

public class ConvertBall : MonoBehaviour {
	
	public bool isHorizontal;
	
	private bool takeEffect = false;
	
	void OnTriggerEnter2D (Collider2D other) {
	
		if(takeEffect && other.gameObject.tag == "Ball"){
			
			// top or bottom converter, check y value
			if (isHorizontal) {
				float absBallY = Mathf.Abs (other.transform.position.y);
				float absThisY = Mathf.Abs (transform.position.y);
				
				// if ball inside, going out
				if(absBallY < absThisY){
					Debug.Log("ball going out, change it to collider");
					other.isTrigger = false;
				}
				// else, outside, going in
				else{
					Debug.Log("ball going in, change it to trigger");
					other.isTrigger = true;
				}
			}
			// left or right converter, check x value
			else {
				float absBallX = Mathf.Abs (other.transform.position.x);
				float absThisX = Mathf.Abs (transform.position.x);
				
				// if ball inside, going out
				if(absBallX < absThisX){
					Debug.Log("ball going out, change it to collider");
					other.isTrigger = false;
				}
				// else, outside, going in
				else{
					Debug.Log("ball going in, change it to trigger");
					other.isTrigger = true;
				}
			}
		}
		
	}
		
	void TakeEffect(float time) {
		takeEffect = true;
		Invoke("LoseEffect", time);
	}
	
	void LoseEffect() {
		takeEffect = false;
	}
}
