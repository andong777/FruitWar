using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleExit);
	}

    void HandleExit(Object obj)
    {
        Application.LoadLevel(0);
    }
}
