using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuUIHelper : MonoBehaviour {

    void Start()
    {
        Button startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(() => { Manager.Game(); });

        Button rankButton = GameObject.Find("RankButton").GetComponent<Button>();
        rankButton.onClick.AddListener(() => { Manager.Rank(); });

        Button helpButton = GameObject.Find("HelpButton").GetComponent<Button>();
        helpButton.onClick.AddListener(() => { Manager.Help(); });

#if UNITY_ANDROID
		// hide exit button because it is not working.
        Button exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(() => { Application.Quit(); });
#endif

        // ad
#if UNITY_ANDROID
        Manager.youmi.Call("addMiniBanner");
#endif

    }
}
