using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

    void Start()
    {
        var button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(() => { Manager.Pause(); });
    }

}
