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

        SaveLoad.Instance.ResetCursor();
        HandleNext();
    }

    void Format(SaveLoad.Data[] data)
    {
        var noBuilder = new System.Text.StringBuilder();
        var nameBuilder = new System.Text.StringBuilder();
        var scoreBuilder = new System.Text.StringBuilder();

        for (int i = 0; i < data.Length && data[i].score > 0; i++)
        {
            noBuilder.Append(data[i].no + "\n");
            nameBuilder.Append(data[i].name + "\n");
            scoreBuilder.Append(data[i].score + "\n");
        }

        noText.text = noBuilder.ToString();
        nameText.text = nameBuilder.ToString();
        scoreText.text = scoreBuilder.ToString();
    }

    void HandlePrev()
    {
        var page = SaveLoad.Instance.Prev();
        Format(page);
    }

    void HandleNext()
    {
        var page = SaveLoad.Instance.Next();
        Format(page);
    }
}
