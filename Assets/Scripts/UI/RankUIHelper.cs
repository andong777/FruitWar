using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankUIHelper : MonoBehaviour {

    public Text noText;
    public Text nameText;
    public Text scoreText;

    public Button prevButton;
    public Button nextButton;

    void Start()
    {
        prevButton.onClick.AddListener(HandlePrev);
        nextButton.onClick.AddListener(HandleNext);
#if UNITY_ANDROID
        Manager.youmi.Call("showSpot");
#endif
        SaveLoad.Instance.ResetCursor();
    }

    void Format(SaveLoad.Data[] data)
    {
		if (data == null)
			return;

        var idBuilder = new System.Text.StringBuilder();
        var nameBuilder = new System.Text.StringBuilder();
        var scoreBuilder = new System.Text.StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            idBuilder.Append(data[i].id + "\n");
            nameBuilder.Append(data[i].name + "\n");
            scoreBuilder.Append(data[i].score + "\n");
        }

        noText.text = idBuilder.ToString();
        nameText.text = nameBuilder.ToString();
        scoreText.text = scoreBuilder.ToString();
    }

    void HandlePrev()
    {
        var page = SaveLoad.Instance.Prev();
		Format (page);
    }

    void HandleNext()
    {
        var page = SaveLoad.Instance.Next();
		Format (page);
    }
}
