using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {

	private const int initialLifeNum = 3;

	private int lifeNum;
	private int brickNum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int BrickNum {
		get{ return brickNum;}
		set{ brickNum = value;}
	}

	public int LifeNum{
		get{ return lifeNum;}
		set{ lifeNum = value;}
	}

	public void killBrick(){
		brickNum -= 1;
		if (brickNum == 0) {
			Debug.Log("You win.");
		}
	}

	public void loseLife() {
		lifeNum -= 1;
		if (lifeNum == 0) {
			Debug.Log("You lose.");		
		}
		Application.LoadLevel(0);
	}
}
