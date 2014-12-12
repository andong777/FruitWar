using UnityEngine;
using System.Collections;

public class AppearObject : MonoBehaviour {

    float destPos;
    float beginPos;

    public float speed = 2f;
    public bool fromLeft = false;

    RectTransform rectTransform = null;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        destPos = rectTransform.position.x;
        var canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        beginPos = canvas.position.x;
        if (fromLeft)
            beginPos -= canvas.rect.width / 2 + rectTransform.rect.width;
        else
            beginPos += canvas.rect.width / 2 + rectTransform.rect.width;
        rectTransform.position = new Vector3(beginPos, rectTransform.position.y, 0);
        StartCoroutine("Appearing");
    
    }

    IEnumerator Appearing()
    {
        Debug.Log("Appearing");
        while ((fromLeft && rectTransform.position.x < destPos) || (!fromLeft && rectTransform.position.x > destPos))
        {
            rectTransform.Translate(new Vector3((destPos - beginPos) * Time.deltaTime * speed, 0, 0));
            yield return null;
        }
    }
}
