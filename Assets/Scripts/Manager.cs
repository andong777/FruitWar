using UnityEngine;
using System.Collections;

public class Manager {

    const int initialLifeNum = 3;
    const int scorePerBrick = 100;

    // game variavles
    private static int stage = 1;   // stage number
	private static int lifeNum = 3; // how many lives left
    private static int totalScore = 0;

    // stage variables
	private static int targetScore; // base score to win
	private static int stageScore = 0;  // score earned
	private static int brickNum;    // how many bricks there
	private static bool released = false;   // ball state
    private static bool won = false;    // mark if player has won, 
                                        // used to handle logic and generate star
	
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

    public static void LoseBrick()
    {
        brickNum--;
        // detect if no bricks left
        if (brickNum == 0)
        {
            Debug.Log("No bricks");
            if (won)
                Break();
            else
                End();
        }
    }

	public static void AddScoreByBrick(int brickNum) {
		stageScore += brickNum * scorePerBrick;
        GameUIHelper.Instance.DrawScore(stageScore);
		if (stageScore >= targetScore && !won) {
            won = true;
            GameObject.Find("Ball").SendMessage("DropStar");
		}
	}

	public static void LoseLife() {
		lifeNum -= 1;
        GameUIHelper.Instance.DrawLife(lifeNum);
		// if no life remaining, show game over
		if (lifeNum == 0) {
            End();
		}
	}
	
	public static void GainLife() {
		lifeNum += 1;
        GameUIHelper.Instance.DrawLife(lifeNum);
	}

	public static int GetStageScore() {
		return stageScore;
	}
	
	public static int GetTargetScore() {
		return targetScore;
	}
	
	public static void SetTargetScoreByBrick(int value) {
		brickNum = value;
		targetScore = brickNum * 2 / 3 * scorePerBrick;
        GameUIHelper.Instance.DrawTargetScore(targetScore);
	}

    public static int GetTotalScore()
    {
        return totalScore;
    }

    public static void Game()
    {
        Application.LoadLevel("Game");
        ResetStage();
        lifeNum = initialLifeNum;

        // at last, update UI
        GameUIHelper.Instance.DrawStage(stage);
        GameUIHelper.Instance.DrawLife(lifeNum);
        GameUIHelper.Instance.DrawScore(0);
        GameUIHelper.Instance.DrawTargetScore(targetScore);
    }

	public static void ResetStage () {
		stageScore = 0;
		released = false;
        won = false;
        SetGame.Instance.Reset();
	}

    public static void NextStage()
    {        
        // reset scene variables
        ResetStage();
        // set game
        SetGame.Instance.Reset();
        // stage num plus 1
        stage += 1;
        // award one life
        GainLife();
        
    }

    public static void Break()
    {
        // add stage score to total score
        totalScore += stageScore;

        Application.LoadLevel("Break");
    }

    public static void End()
    {
        Application.LoadLevel("End");
    }

    public static void Rank()
    {
        Application.LoadLevel("Rank");
    }

    public static void Help()
    {
        Application.LoadLevel("Help");
    }

    public static void Menu()
    {
        Application.LoadLevel("Menu");
    }

}
