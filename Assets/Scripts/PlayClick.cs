using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayClick : MonoBehaviour {

    public AudioClip clickAudio;

    public Button[] buttons;

    void Start()
    {
        foreach(var btn in buttons){
            btn.onClick.AddListener(() => { AudioSource.PlayClipAtPoint(clickAudio, transform.position); });
        }
    }
}
