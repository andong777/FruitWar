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
		stageScore += brickNum * 1000;
		if (stageScore >= targetScore && !won) {
            won = true;
            GameObject.Find("Ball").SendMessage("DropStar");
		}
        try
        {
            GameUIHelper.Instance.DrawScore(stageScore);
        }catch(System.Exception){ }
	}

	public static void LoseLife() {
		lifeNum -= 1;
		// if no life remaining, show game over
		if (lifeNum == 0) {
            End();
		}
        try
        {
            GameUIHelper.Instance.DrawLife(lifeNum);
        }
        catch (System.Exception) { }
	}
	
	public static void GainLife() {
		lifeNum += 1;
        try
        {
            GameUIHelper.Instance.DrawLife(lifeNum);
        }
        catch (System.Exception) { }
	}

    public static int GetLifeNum()
    {
        return lifeNum;
    }

    public static int GetStage()
    {
        return stage;
    }

	public static int GetStageScore() {
		return stageScore;
	}
	
	public static int GetTargetScore() {
		return targetScore;
	}
	
	public static void SetTargetScoreByBrick(int value) {
		brickNum = value;
		targetScore = brickNum * 3 / 5 * scorePerBrick;
        try
        {
            GameUIHelper.Instance.DrawTargetScore(targetScore);
        }
        catch (System.Exception) { }
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

    }

	public static void ResetStage () {
		stageScore = 0;
		released = false;
        won = false;
        var setGame = SetGame.Instance;
        if(setGame!=null)
            setGame.Reset();

	}

    public static void NextStage()
    {
        Application.LoadLevel("Game");
        // stage num plus 1
        stage += 1;
        // award one life
        GainLife();
        // reset scene variables
        ResetStage();
        
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
