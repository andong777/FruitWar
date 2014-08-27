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

    public Image propertyImage;

    private GameUIHelper() {}

    public static GameUIHelper Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
        if (sprite == null)
        {
            propertyImage.enabled = false;
        }
        else
        {
            propertyImage.enabled = true;
            var rt = propertyImage.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(sprite.bounds.size.x, sprite.bounds.size.y);
            propertyImage.sprite = sprite;
            
        }
    }
}
