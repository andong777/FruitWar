using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Pad")
        {
            // catch star, go to next stage
            Debug.Log("going to next stage");
            Manager.Break();
        }
    }

}
