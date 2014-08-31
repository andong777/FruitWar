using UnityEngine;
using System.Collections;

public class ShootGun : MonoBehaviour {
	
	int bulletNum = 0;	// set no bullet at the beginning
	float speed = 10f;
	
	public GameObject bullet;
	
	// Use this for initialization
	void Start () {
        StartCoroutine("hintAtTheBeginning");
	}

    IEnumerator hintAtTheBeginning()
    {
        yield return new WaitForSeconds(3f);
        if (!Manager.Released)
        {
            GameUIHelper.Instance.DrawHint("寻找合适的角度，点击屏幕发射");
        }
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && bulletNum > 0 && Manager.Released && Time.timeScale > 0f){
			Debug.Log("shoot the gun");
            audio.Play();
			Vector3 position = transform.position + new Vector3(0, gameObject.collider2D.bounds.size.y * 2, 0);
			var aBullet = Instantiate(bullet, position, Quaternion.identity) as GameObject;
			aBullet.rigidbody2D.velocity = new Vector2(0, speed);
			bulletNum --;
            Destroy(aBullet, 3f);   // destroy it after seconds
            // update UI
            GameUIHelper.Instance.DrawBullet(bulletNum);
		}
	}
	
	void LoadBullets () {
		// by design, bullets can be overlaid
		bulletNum += 5;
        // update UI
        GameUIHelper.Instance.DrawBullet(bulletNum);
	}

    void UnLoadBullets()
    {
        bulletNum = 0;
        GameUIHelper.Instance.DrawBullet(bulletNum);
    }
}
