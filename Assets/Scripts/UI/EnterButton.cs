using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnterButton : MonoBehaviour {

	public InputField input;
	public TextAsset filterAsset;
	string[] filters = null;

	string errorString = "请不要包含敏感词汇！";

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleEnter);
		filters = filterAsset.text.Split('\n');
    }

    void HandleEnter()
    {
        string name = input.text;
        if (name == null || name == "")
			name = "无名英雄";
		if (CheckName(name)) {
			int score = Manager.GetTotalScore();
			SaveLoad.Instance.Save(new SaveLoad.Data(name, score));
			Manager.Menu();
		} else {
			EventSystem.current.SetSelectedGameObject(input.gameObject, null);
			input.OnPointerClick(new PointerEventData(EventSystem.current));
			input.text = "";
			((Text)input.placeholder).text = errorString;
			input.placeholder.color = Color.red;
		}
        
    }

	bool CheckName(string name)
	{
		Debug.Log ("Name: " + name);
		if (filterAsset != null){
			if (filters == null) {
				filters = filterAsset.text.Split('\n');
			}
			foreach(var f in filters){
				if(name.Trim().Equals(f.Trim(), System.StringComparison.OrdinalIgnoreCase))
					return false;
			}
		}
		return true;
	}
}
