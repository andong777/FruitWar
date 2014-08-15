using UnityEngine;
using System.Collections;

public class DrawUI : MonoBehaviour {

	void OnGUI () {
	
		// draw score
		GUI.Label(new Rect(Screen.width / 2 - 70, Screen.height / 5, 140, 100), "Score: " + GameInfo.Score);
		
		// draw reset button
		if (GUI.Button(new Rect(Screen.width / 8 - 50, Screen.height / 5, 60, 100), "Reset")) {
			GameObject.Find("GameManager").SendMessage("SetPadAndBall");
			GameInfo.Reset();
			Application.LoadLevel(0);
		}
		
		// draw exit button
		if (GUI.Button(new Rect(Screen.width / 8 + 50, Screen.height / 5, 60, 100), "Exit")) {
			// TODO
			// Application.LoadLevel(0);
		}
	}
}
