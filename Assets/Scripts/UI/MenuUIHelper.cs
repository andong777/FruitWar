using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuUIHelper : MonoBehaviour {

    void Start()
    {
		SaveLoad.Instance.authenticate ();

        Button startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(() => { 
			Manager.Game(); 
		});

        Button rankButton = GameObject.Find("RankButton").GetComponent<Button>();
		rankButton.onClick.AddListener(() => { 
			SaveLoad.Instance.DoLeaderboard();	
//			Manager.Rank(); 
		});

        Button helpButton = GameObject.Find("HelpButton").GetComponent<Button>();
        helpButton.onClick.AddListener(() => { 
			Manager.Help(); 
		});

    }
}
