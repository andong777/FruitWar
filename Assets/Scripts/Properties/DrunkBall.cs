using UnityEngine;
using System.Collections;

public class DrunkBall : MonoBehaviour {

    private float time = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pad")
        {
            Debug.Log("get drunkball");            
            GameObject.Find("Ball").SendMessage("MakeDrunkBall", time);
        }
    }
}
