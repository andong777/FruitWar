using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUIHelper : MonoBehaviour {

    private static GameUIHelper _instance;

    public Text scoreText;
    public Text targetScoreText;
    public Text stageText;
    public Text heartText;


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
        var panel = GameObject.Find("HUD");
        var heart1 = GameObject.Find("Heart1").GetComponent<Image>();
        var heart2 = GameObject.Find("Heart2").GetComponent<Image>();
        var heart3 = GameObject.Find("Heart3").GetComponent<Image>();

        if (panel == null || heart1 == null || heart2 == null || heart3 == null)
            return;

        if (lifeNum < 3)
        {
            heart3.enabled = false;
            if (lifeNum < 2)
            {
                heart2.enabled = false;
                if (lifeNum < 1)
                {
                    heart1.enabled = false;
                }
                else
                {
                    heart1.enabled = true;
                }
            }
            else
            {
                heart2.enabled = true;
            }
        }
        else
        {
            heart3.enabled = true;
        }
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

}
