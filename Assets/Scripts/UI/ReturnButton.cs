using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour {

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => { Manager.End(); });
    }

}
