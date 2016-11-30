using UnityEngine;
using System.Collections;

public class EnemyBullet_03 : MonoBehaviour {

	private Rigidbody2D thebody;
	private PlayerController theplayer;
	public float speed;
	private bool flag = false;
	private Vector2 _dir;

	// Use this for initialization
	void Start () {
		thebody = GetComponent <Rigidbody2D> ();
		theplayer = FindObjectOfType <PlayerController> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		if(flag==false){
			// check rotation and direction once 
			Vector2 targetRotation = theplayer.transform.position - this.transform.position; // just awsome
			float angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, angle-269f);

			_dir = (theplayer.transform.position - transform.position).normalized;
			flag = true;
			//Debug.Log ("flag");
		}
		thebody.velocity = _dir*speed*Time.deltaTime;
	}

	void OnEnable(){
		flag = false;
	}

}


