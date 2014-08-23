using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleReset);
	}

    void HandleReset(Object obj)
    {
        GameObject.Find("GameManager").SendMessage("Reset");
        SetGame.Instance.Reset();
        Manager.Reset();
    }
	
}
