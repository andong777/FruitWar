using UnityEngine;
using System.Collections;

public class DropProperty : MonoBehaviour {

	// the probability of generating property
	[RangeAttribute(0, 1)]
	public float propertyProbability = 0.2f;

	// properties
	public GameObject[] properties;
	
	void Start () {
		Random.seed = System.DateTime.Now.Millisecond;
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Brick"){
			float probable = Random.Range(0f, 1f);
			Debug.Log(probable);
			if(probable < propertyProbability){
				int index = Random.Range(0, properties.Length - 1);	// choose a property
				Instantiate(properties[index], transform.position, Quaternion.identity);
			}
		}
	}
}
