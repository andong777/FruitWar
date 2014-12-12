using UnityEngine;
using System.Collections;

public class ChooseSprite : MonoBehaviour {

    public Sprite[] sprites;

    void Start()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        Choose();
    }

    void Choose()
    {
        int index = Random.Range(0, sprites.Length);
        try
        {
            GetComponent<SpriteRenderer>().sprite = sprites[index];
        }
        catch (System.Exception)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = sprites[index];
        }
    }
}
