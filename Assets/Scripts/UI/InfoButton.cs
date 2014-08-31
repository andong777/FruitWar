using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour {

    public Text hintText;
    public Sprite infoSprite;
    public Sprite noInfoSprite;

    bool enabled;
    Color hideColor = new Color(1, 1, 1, 0);
    Color showColor;

    void Start()
    {
        // start enabled
        enabled = true;
        showColor = hintText.color;

        GetComponent<Button>().onClick.AddListener(HandleInfo);
    }

    void HandleInfo()
    {
        enabled = !enabled;
        if (enabled)
        {
            GetComponent<Image>().sprite = infoSprite;
            hintText.color = showColor;
        }
        else
        {
            GetComponent<Image>().sprite = noInfoSprite;
            hintText.color = hideColor;
        }
    }

}
