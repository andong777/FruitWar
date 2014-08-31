using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUIHelper : MonoBehaviour {

    private static GameUIHelper _instance;

    public Text scoreText;
    public Text targetScoreText;
    public Text stageText;
    public Text heartText;
    public Text bulletText;
    
    public Text hintText;
    float hintDisappearTime = 0f;

    public Image propertyImage;
    float propertyImageSize = 50f;

    private GameUIHelper() {}

    public static GameUIHelper Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
    }

    public void DrawLife(int lifeNum)
    {
        heartText.text = "" + lifeNum;
    }

    public void DrawTargetScore(int targetScore)
    {
        targetScoreText.text = "目标分数：\n" + targetScore;
    }

    public void DrawScore(int stageScore)
    {
        scoreText.text = stageScore + "";
    }

    public void DrawStage(int stage)
    {
        stageText.text = "第" + stage + "关";
    }

    public void DrawBullet(int bulletNum)
    {
        bulletText.text = "" + bulletNum;
    }

    public void DrawProperty(Sprite sprite)
    {
        var rt = propertyImage.rectTransform;
        if (sprite == null)
        {
            Debug.Log("clean property");
            rt.sizeDelta = new Vector2(propertyImageSize, propertyImageSize);
            propertyImage.enabled = false;
        }
        else
        {
            Debug.Log("draw property");
            propertyImage.enabled = true;
            rt.sizeDelta = new Vector2(rt.sizeDelta.y * sprite.bounds.size.x / sprite.bounds.size.y, rt.sizeDelta.y);
            propertyImage.sprite = sprite;
            
        }

    }

    void Update()
    {
        if (Time.frameCount % 50 == 0 && Time.time > hintDisappearTime)
        {
            hintText.text = "";
        }
    }

    public void DrawHint(string hint)
    {
        hintDisappearTime = Time.time + 3f;
        hintText.text = hint;
    }
}
