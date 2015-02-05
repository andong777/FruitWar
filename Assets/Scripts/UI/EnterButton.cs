using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnterButton : MonoBehaviour {

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleEnter);
    }

    void HandleEnter()
    {
		int score = Manager.GetTotalScore();
		SaveLoad.Instance.Save (score);
		Manager.Menu ();
    }
}
