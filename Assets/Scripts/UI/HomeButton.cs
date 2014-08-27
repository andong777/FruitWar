using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour {

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => { Manager.Menu(); });
    }
}
