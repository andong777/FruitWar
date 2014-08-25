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
        GetComponent<SpriteRenderer>().sprite = sprites[index];
    }
}
