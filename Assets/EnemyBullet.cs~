using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	private Rigidbody2D thebody;
	public float speed;
	// Use this for initialization
	void Start () {
		//thebody = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		straightFire ();
	}

	void straightFire(){
		transform.Translate (Vector2.down * Time.deltaTime * speed);
		//thebody.velocity = Vector2.down * Time.deltaTime * 50f;
	}

}
