using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour {

    public Text hintText;
    public Sprite infoSprite;
    public Sprite noInfoSprite;

    bool banned;
    Color hideColor = new Color(1, 1, 1, 0);
    Color showColor;

    void Start()
    {
        // start enabled
        banned = false;
        showColor = hintText.color;

        GetComponent<Button>().onClick.AddListener(HandleInfo);
    }

    void HandleInfo()
    {
        banned = !banned;
        if (banned)
        {
            GetComponent<Image>().sprite = noInfoSprite;
            hintText.color = hideColor;
        }
        else
        {
            GetComponent<Image>().sprite = infoSprite;
            hintText.color = showColor;
        }
    }

}
