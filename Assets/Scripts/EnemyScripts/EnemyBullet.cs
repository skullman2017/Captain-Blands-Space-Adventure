using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

 
	public float speed;
	// Use this for initialization
	void Start () {
       
	}

	// Update is called once per frame
	void FixedUpdate () {
		straightFire ();
	}

	void straightFire(){
		transform.Translate (Vector2.down * Time.deltaTime * speed);
	}

}
