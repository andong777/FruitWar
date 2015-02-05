using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

    public Button stop;
    public Text score;
    public Image award;

    public Sprite newRecordSprite;

    int startScore;
    int endScore;

	void Start () {
#if UNITY_ANDROID
        Manager.youmi.Call("showSpot");
#endif
        endScore = Manager.GetTotalScore();
        startScore = endScore - Manager.GetStageScore();

        Debug.Log(startScore + "->" + endScore);
        stop.onClick.AddListener(HandleStop);

        StartCoroutine("Running");
	}

    // let score run
    IEnumerator Running()
    {
        Debug.Log("Running score");
        for (int i = startScore; i <= endScore; i += 100)
        {
            score.text = i + "";
            yield return new WaitForSeconds(0.1f);
        }
    }

    void HandleStop()
    {
        StopCoroutine("Running");
        score.text = endScore + "";
    }

}
