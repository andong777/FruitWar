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

        HandleNext();
    }

    void Format(SaveLoad.Data[] data)
    {
        var noBuilder = new System.Text.StringBuilder();
        var nameBuilder = new System.Text.StringBuilder();
        var scoreBuilder = new System.Text.StringBuilder();

        noBuilder.Append("<b>No.</b>");
        nameBuilder.Append("<b>玩家</b>");
        scoreBuilder.Append("<b>得分</b>");

        for (int i = 0; i < data.Length && data[i].score > 0; i++)
        {              
            noBuilder.Append("\n" + data[i].no);
            nameBuilder.Append("\n" + data[i].name);
            scoreBuilder.Append("\n" + data[i].score);
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
