using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {

	private static int targetScore;
	private static bool released = false;
	private static int lifeNum = 3;
	private static int score = 0;
	private static int brickNum = 40;
	
	
	public static bool Released { 
		get{ return released;}
		set{ released = value;}
	}

	public static void KillBrick(){
		// the order is important: check score first, then check brick num
		do{
			score += 1000;
			if (score >= targetScore) {
				Win ();
				break;
			}
			LoseBrick();		
		}while(false);
	}
	
	public static void AddScoreByBrick(int brickNum) {
		score += brickNum * 1000;
		if (score >= targetScore) {
			Win ();
		}
	}

	public static void LoseLife() {
		lifeNum -= 1;
		// if no life remaining, show game over
		if (lifeNum == 0) {
			Lose ();
		}
	}
	
	public static void GainLife() {
		lifeNum += 1;
	}
	
	public static int GetScore() {
		return score;
	}
	
	public static int GetTargetScore() {
		return targetScore;
	}
	
	public static int GetBrickNum() {
		return brickNum;
	}
	
	public static void LoseBrick() {
		brickNum --;
		// detect if no bricks left
		if(brickNum == 0){
			Debug.Log ("No bricks");
			Lose ();
		}			
	}
	
	public static void SetTargetScoreByBrick(int value) {
		brickNum = value;
		targetScore = brickNum * 2 / 3 * 1000; 
	}
	
	private static void Win() {
		Debug.Log("You win.");
		Application.LoadLevel(0);
	}
	
	private static void Lose() {
		Debug.Log("You lose.");
		Application.LoadLevel(0);
	}
	
	public static void Reset () {
		score = 0;
		lifeNum = 3;
		released = false;
	}
	
}
