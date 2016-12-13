using UnityEngine;
using System.Collections;

public class Enemy_05 : MonoBehaviour {

	public float moveSpeed;
	private Vector2 posToStop;
	private float reachDis = 0.01f;
	float distance = -4f;
	private PlayerController theplayer;
	 
	bool canFire=false;
	bool canRotate = false;
	bool canMove = false;
	bool _moveLeft = true;

	Vector2 rightPos;
	Vector2 leftPos;

	//public GameObject test;

	// Use this for initialization
	void Start () {
		theplayer = FindObjectOfType <PlayerController> ();
		posToStop = new Vector2 (transform.position.x, transform.position.y - 4f);


	}
		
	void fire(){

		for(int i=0;i<3;i++){
			Vector3 rot = transform.rotation.eulerAngles;

			GameObject go = EnemyBulletPooler._Instance.getBullet ((int)EnemyBulletPooler.Enemies.Enemy_01);
			go.transform.position = this.transform.position;
			//GameObject go = Instantiate (test, transform.position, Quaternion.identity) as GameObject;

			if (i == 0) {
				go.transform.rotation = this.transform.rotation;
			}
			else if (i == 1) {
				rot.z -= 15f;
				go.transform.rotation = Quaternion.Euler (rot);
			}
			else {
				rot.z += 15f;
				go.transform.rotation = Quaternion.Euler (rot);
			}

			go.SetActive (true);
		}

	}

	// Update is called once per frame
	void Update () {
		if(distance != 0f) {
			distance = Vector2.Distance (posToStop, transform.position);
			transform.position = Vector2.MoveTowards (transform.position, posToStop, Time.deltaTime * moveSpeed);
		}

		if(distance<=0 & canFire==false){
			canMove = true;
			canFire = true;
			canRotate = true;

			leftPos = transform.position;
			rightPos = transform.position;

			rightPos.x -= 1f;
			leftPos.x += 1f;

			fire ();
			//Debug.Log ("less than zero");
		}

		if(canRotate){
			//rotation
			Vector2 targetRotation = (theplayer.transform.position - this.transform.position).normalized; // just awsome
			float angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, angle-269f);

			moveLeftAndRight ();
		}

	} // end 

	void moveLeftAndRight(){
		if (_moveLeft) {
			// moveleft
			if (Vector2.Distance (transform.position, leftPos) > 0) {
				transform.position = Vector2.MoveTowards (transform.position, leftPos, Time.deltaTime * 1.2f);
			}else{
				fire ();
				_moveLeft = !_moveLeft;
			}
			//Debug.Log ("lefpos : " + Vector2.Distance (transform.position, leftPos));
		} 
		else{
			// move right
			if (Vector2.Distance (transform.position, rightPos) > 0) {
				transform.position = Vector2.MoveTowards (transform.position, rightPos, Time.deltaTime * 1.2f);
			}else{
				
				 fire ();
				_moveLeft = !_moveLeft;
			}
			//Debug.Log ("right pos " + Vector2.Distance (transform.position, rightPos));
		}
	}
		

}
