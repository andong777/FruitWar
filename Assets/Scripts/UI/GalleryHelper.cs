using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GalleryHelper : MonoBehaviour {

    public Sprite[] sprites;

    public Image gallery;
    public Button prev;
    public Button next;

    int index;

    void Start()
    {
        index = 0;
        prev.onClick.AddListener(Prev);
        next.onClick.AddListener(Next);
    }

    void Prev()
    {
        if (index > 0)
        {
            gallery.sprite = sprites[--index];
        }
    }

    void Next()
    {
        if(index < sprites.Length - 1){
            gallery.sprite = sprites[++index];
        }
    }
}
