using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
            AddScoreByBrick(1);
			LoseBrick();		
		}while(false);
	}
	
	public static void AddScoreByBrick(int brickNum) {
		score += brickNum * 1000;
        var scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = score + "";
		if (score >= targetScore) {
			Win ();
		}
	}

	public static void LoseLife() {
		lifeNum -= 1;
        DrawLife();
		// if no life remaining, show game over
		if (lifeNum == 0) {
			Lose ();
		}
	}
	
	public static void GainLife() {
		lifeNum += 1;
        // set max value to 3 to simplify draw problem
        if (lifeNum > 3)
            lifeNum = 3;
        DrawLife();
	}

    private static void DrawLife()
    {
        var panel = GameObject.Find("HUD");
        var heart1 = GameObject.Find("Heart1").GetComponent<Image>();
        var heart2 = GameObject.Find("Heart2").GetComponent<Image>();
        var heart3 = GameObject.Find("Heart3").GetComponent<Image>();
        if (lifeNum < 3)
        {
            heart3.enabled = false;
            if (lifeNum < 2)
            {
                heart2.enabled = false;
                if (lifeNum < 1)
                {
                    heart1.enabled = false;
                }
                else
                {
                    heart1.enabled = true;
                }
            }
            else
            {
                heart2.enabled = true;
            }
        }
        else
        {
            heart3.enabled = true;
        }         
    }

	public static int GetScore() {
		return score;
	}
	
	public static int GetTargetScore() {
		return targetScore;
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
        var targetScoreText = GameObject.Find("TargetScore").GetComponent<Text>();
        targetScoreText.text = "目标分数：\n" + targetScore;
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
