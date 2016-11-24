﻿using UnityEngine;
using System.Collections;

public class pathFollower : MonoBehaviour {

	private PathEditor pathtofollow;

	private int currentWayPointID = 0;
	public float speed;
	private float reachDistance = 0.1f;
	private float rotationSpeed = 5f;
	public string pathName = "Path 1";

	public int Health;
	[Tooltip("Player bullet damage")]
	public int damage; // player bullet hit damage

	private int initialHealth;
	private int cnt = 0;

	// Use this for initialization
	void Start () {
		initialHealth = Health;
		pathtofollow = GameObject.Find(pathName).GetComponent<PathEditor>();
	}

	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance(pathtofollow.pathsObject[currentWayPointID].position, transform.position);
		transform.position = Vector2.MoveTowards(transform.position, pathtofollow.pathsObject[currentWayPointID].position, Time.deltaTime * speed);

/*
		Vector2 targetRotation = pathtofollow.pathsObject[currentWayPointID].position - transform.position;
        float angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;


        var rotation = Quaternion.LookRotation(pathtofollow.pathsObject[currentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, angle);

*/

		if(distance <= reachDistance){
			currentWayPointID++;
		}

		if(currentWayPointID >= pathtofollow.pathsObject.Count){
			currentWayPointID = pathtofollow.pathsObject.Count-1;
			currentWayPointID = 0;
			gameObject.SetActive (false);
		}

		//transform.rotation = Quaternion.LookRotation (pathtofollow.pathsObject [currentWayPointID].position);
		//Debug.Log ("current way point ID :"+currentWayPointID);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Bullet"){

			// emitter 
			GameObject hitEmitter = ExplosionPooler._Instance.getExplosion ((int)ExplosionPooler.explosionFabs.hitEmitter);
			hitEmitter.transform.position = col.gameObject.transform.position;
			hitEmitter.SetActive (true); 

			giveDamage (damage);
		}
		else if(col.gameObject.tag == "Player"){
			//Debug.Log ("ship");
			giveDamage (Health+10); // destroy
		}
		else if(col.gameObject.tag == "KillBox"){
			Health = initialHealth;
		}
	} // end 

	void giveDamage(int _dmg){

		if(Health>0){
			Health -= _dmg;
		}
		else{
			currentWayPointID = 0;
			gameObject.SetActive(false);

			GameObject explsion = ExplosionPooler._Instance.getExplosion ((int)ExplosionPooler.explosionFabs.enemyExplosion);
			explsion.transform.position = transform.position;
			explsion.SetActive (true);

			Health = initialHealth;
		}
	}
}
