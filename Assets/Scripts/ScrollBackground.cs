using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

    public Sprite[] sprites;

    Sprite theSprite = null;

    Transform bg1;
    Transform bg2;

    public float movingSpeed = 1f;

    void Awake()
    {
        bg1 = GameObject.Find("BG1").transform;
        bg2 = GameObject.Find("BG2").transform;
    }

	void Start () {

        var sr1 = bg1.GetComponent<SpriteRenderer>();
        var sr2 = bg2.GetComponent<SpriteRenderer>();

        // first choose a sprite
        int index = Random.Range(0, sprites.Length - 1);
        theSprite = sprites[index];
        sr1.sprite = theSprite;
        sr2.sprite = theSprite;

        // adjust scale to fill in y axis
        float ratio = Camera.main.orthographicSize * 2 / theSprite.bounds.size.y;
        bg1.localScale = new Vector3(ratio, ratio, 1);
        bg2.localScale = new Vector3(ratio, ratio, 1);

        // align left
        float screenHalfWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        float pos = theSprite.bounds.size.x / 2 - screenHalfWidth;
        bg1.position = new Vector3(pos, 0, 0);
        bg2.position = new Vector3(pos + theSprite.bounds.size.x, 0, 0);
        Debug.Log(theSprite.bounds.size.x);
        Debug.Log(screenHalfWidth);
	}

    void Update()
    {        
        float threshold = -3f;
        bg1.Translate(new Vector3(-1 * movingSpeed * Time.deltaTime, 0, 0));
        bg2.Translate(new Vector3(-1 * movingSpeed * Time.deltaTime, 0, 0));
        if (bg1.position.x + theSprite.bounds.size.x < 0)
        {
            bg1.position = bg2.position + new Vector3(theSprite.bounds.size.x, 0, 0);
        }
        if (bg2.position.x + theSprite.bounds.size.x < 0)
        {
            bg2.position = bg1.position + new Vector3(theSprite.bounds.size.x, 0, 0);
        }
    }

}
