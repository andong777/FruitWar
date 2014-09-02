using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GalleryHelper : MonoBehaviour {

    public Sprite[] sprites;

    public Image gallery;
    public Button prev;
    public Button next;

    Image prevImage;
    Image nextImage;

    Color hideColor = new Color(1, 1, 1, 0);
    Color showColor = new Color(1, 1, 1, 180f / 255f);

    int index;

    void Start()
    {
        index = 0;
        prev.onClick.AddListener(Prev);
        next.onClick.AddListener(Next);
        prevImage = prev.GetComponent<Image>();
        nextImage = next.GetComponent<Image>();
        prevImage.color = hideColor;    // hide prev button at the beginning
#if UNITY_ANDROID
        Manager.youmi.Call("showSpot");
#endif
    }

    void Prev()
    {
        if (index > 0)
        {
            gallery.sprite = sprites[--index];
        }
        if(index == 0)
        {
            prevImage.color = hideColor;
        }
        if (index < sprites.Length - 1)
        {
            nextImage.color = showColor;
        }
    }

    void Next()
    {
        if(index < sprites.Length - 1){
            gallery.sprite = sprites[++index];
        }
        if(index == sprites.Length - 1)
        {
            nextImage.color = hideColor;
        }
        if (index > 0)
        {
            prevImage.color = showColor;
        }
    }
}
