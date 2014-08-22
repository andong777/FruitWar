using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankButton : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleRank);
    }

    void HandleRank(Object obj)
    {
        Application.LoadLevel(2);
    }
}
