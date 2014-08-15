using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {

	private static bool released = false;

	private static int lifeNum = 3;
	private static int score = 0;

	public static bool Released { 
		get{ return released;}
		set{ released = value;}
	}

	public static void killBrick(){
		// TODO
	}

	public static void loseLife() {
		lifeNum -= 1;
		// if no life remaining, show game over
		if (lifeNum == 0) {
			Debug.Log("You lose.");		
			// Application.LoadLevel(0);
		}
	}
	
	public static int Score {
		get { return score; }
	}
	
	public static void Reset () {
		score = 0;
		lifeNum = 3;
		released = false;
	}
}
