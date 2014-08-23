using UnityEngine;
using System.Collections;

public class Manager {

    // game variavles
    private static int stage = 1;   // stage number
	private static int lifeNum = 3; // how many lives left
    private static int totalScore = 0;

    // stage variables
	private static int targetScore; // base score to win
	private static int stageScore = 0;  // score earned
	private static int brickNum;    // how many bricks there
	private static bool released = false;   // ball state
    private static bool hasStar = false;    // if star generated
	
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
		stageScore += brickNum * 1000;
        GameUIHelper.Instance.DrawScore(stageScore);
		if (stageScore >= targetScore && !hasStar) {
            hasStar = true;
            GameObject.Find("Ball").SendMessage("DropStar");
		}
	}

	public static void LoseLife() {
		lifeNum -= 1;
        GameUIHelper.Instance.DrawLife(lifeNum);
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
        GameUIHelper.Instance.DrawLife(lifeNum);
	}

	public static int GetStageScore() {
		return stageScore;
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
        GameUIHelper.Instance.DrawTargetScore(targetScore);
	}
	
	private static void Win() {
		Debug.Log("You win.");
        NextStage();
	}
	
	private static void Lose() {
		Debug.Log("You lose.");
		Application.LoadLevel(0);
	}
	
	public static void Reset () {
		stageScore = 0;		
		released = false;
        hasStar = false;
	}

    public static void NextStage()
    {        
        // add stage score to total score
        totalScore += stageScore;
        // stage num plus 1
        stage += 1;
        GameUIHelper.Instance.DrawStage(stage);
        // award one life
        GainLife();
        // reset scene variables
        Reset();
        // set game
        SetGame.Instance.Reset();
    }

}
