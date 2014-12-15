using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnterButton : MonoBehaviour {

    public Text input;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleEnter);
    }

    void HandleEnter()
    {
        string name = input.text;
        if (name == null || name == "")
			name = "无名英雄";
        Debug.Log(name);
        int score = Manager.GetTotalScore();
        SaveLoad.Instance.Save(new SaveLoad.Data(name, score));

        Manager.Menu();
    }
}
