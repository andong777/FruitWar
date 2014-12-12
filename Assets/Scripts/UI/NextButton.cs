using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextButton : MonoBehaviour {

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => { Manager.NextStage(); });
    }

}
