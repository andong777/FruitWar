using UnityEngine;
using System.Collections;

public class DrawUI : MonoBehaviour {

	public GUISkin myGUISkin;

	public float topPos = Screen.height / 20;
	public float buttonWidth = 60;
	public float buttonHeight = 30;

	void OnGUI () {
		GUI.skin = myGUISkin;
		
		// draw score
		GUI.Label(new Rect(Screen.width / 2 - 70, topPos, 140, 100), "Score: " + GameInfo.Score);
		
		// draw reset button
		if (GUI.Button(new Rect(Screen.width / 8 - 50, topPos, buttonWidth, buttonHeight), "Reset")) {
			GameObject.Find("GameManager").SendMessage("SetPadAndBall");
			GameObject.Find("GameManager").SendMessage("SpawnBricks");
			GameInfo.Reset();
			Application.LoadLevel(1);
		}
		
		// draw exit button
		if (GUI.Button(new Rect(Screen.width / 8 + 50, topPos, buttonWidth, buttonHeight), "Exit")) {
			Application.LoadLevel(0);
		}
	}
}
