using UnityEngine;
using System.Collections;

public class DrawUI : MonoBehaviour {

	float topPos = Screen.height / 20;
	float buttonWidth = 60;
	float buttonHeight = 30;

	void OnGUI () {
		
		// draw score
		GUIStyle labelStyle = new GUIStyle();
		labelStyle.fontSize = 20;
		labelStyle.alignment = TextAnchor.UpperCenter;
		labelStyle.normal.textColor = Color.white;
		GUI.Label(new Rect(Screen.width / 2 - 50, topPos, 100, 50), "Score:\n" + GameInfo.GetScore(), labelStyle);
		
		// draw target score
		labelStyle.fontSize = 16;
		GUI.Label(new Rect(Screen.width *3 / 4, topPos, 70, 30), "Target Score:\n" + GameInfo.GetTargetScore(), labelStyle);
		
		// draw reset button
		if (GUI.Button(new Rect(Screen.width / 4, topPos, buttonWidth, buttonHeight), "Reset")) {
			GameObject.Find("GameManager").SendMessage("SetPadAndBall");
			GameObject.Find("GameManager").SendMessage("SpawnBricks");
			GameInfo.Reset();
		}
		
		// draw exit button
		if (GUI.Button(new Rect(Screen.width / 8, topPos, buttonWidth, buttonHeight), "Exit")) {
			Application.LoadLevel(0);
		}
	}
}
