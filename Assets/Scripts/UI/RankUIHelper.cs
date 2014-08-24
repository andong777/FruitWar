using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankUIHelper : MonoBehaviour {

    public Text content;
    public Button prevButton;
    public Button nextButton;

    void Start()
    {
        prevButton.onClick.AddListener(HandlePrev);
        nextButton.onClick.AddListener(HandleNext);

        HandleNext();
    }

    string Format(SaveLoad.Data[] data)
    {
        var builder = new System.Text.StringBuilder();
        builder.Append("No.\t\tName\t\tScore\n");
        for (int i = 0; i < data.Length && data[i].score > 0; i++)
        {   
            builder.Append("\n" + (i + 1) + "\t\t" + data[i].name + "\t\t" + data[i].score + '\n');
        }
        return builder.ToString();
    }

    void HandlePrev()
    {
        var page = SaveLoad.Instance.Prev();
        content.text = Format(page);
    }

    void HandleNext()
    {
        var page = SaveLoad.Instance.Next();
        content.text = Format(page);
    }
}
