using UnityEngine;
using System.Collections;

public class SetStartTime : MonoBehaviour {

    void Start()
    {
        var button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(()=>{ GameObject.Find("Ball").SendMessage("SetStartTime"); });
    }
}
