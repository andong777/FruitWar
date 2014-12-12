using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnterButton : MonoBehaviour {

    public Text input;
    string placeHolder = "请输入您的大名";

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleEnter);
        input.text = placeHolder;
    }

    void HandleEnter()
    {
        string name = input.text;
        if (name == null || name == "" || name == placeHolder)
            name = "幽灵";
        Debug.Log(name);
        int score = Manager.GetTotalScore();
        SaveLoad.Instance.Save(new SaveLoad.Data(name, score));

        Manager.Menu();
    }
}
