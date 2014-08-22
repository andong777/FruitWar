using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleStart);
    }

    void HandleStart(Object obj)
    {
        Application.LoadLevel(1);
    }
}
