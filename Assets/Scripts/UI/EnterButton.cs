using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnterButton : MonoBehaviour {

    bool hasInput = false; // if user has input
    public Text input;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleEnter);
    }

    void HandleEnter()
    {
        string name = input.text;
        if (!hasInput || name == null || name == "")
            name = "幽灵";
        Debug.Log(name);
        int score = Manager.GetTotalScore();
        SaveLoad.Instance.Save(new SaveLoad.Data(name, score));
    }
}
