using UnityEngine;
using System.Collections;

public class pathFollower : MonoBehaviour {

	[SerializeField]
	private bool straightShoot;
	private bool singleShot = true;

	private PathEditor pathtofollow;

    [HideInInspector]
	public int currentWayPointID = 0;

	public float speed;
	private float reachDistance = 0.1f;
	private float rotationSpeed = 5f;
	public string pathName = "Path 1";

	public int Health;
	[Tooltip("Player bullet damage")]
	public int damage; // player bullet hit damage

	private int initialHealth;
	private int mid = 0;

	private PlayerController theplayer;

	// Use this for initialization
	void Start () {
		theplayer = FindObjectOfType <PlayerController> ();

		initialHealth = Health;
		pathtofollow = GameObject.Find(pathName).GetComponent<PathEditor>();
		mid = pathtofollow.pathsObject.Count+1;
		mid = mid / 2;
	}

	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance(pathtofollow.pathsObject[currentWayPointID].position, transform.position);
		transform.position = Vector2.MoveTowards(transform.position, pathtofollow.pathsObject[currentWayPointID].position, Time.deltaTime * speed);


		if(mid-1==currentWayPointID && singleShot == true && straightShoot==true){
			singleShot = false;
			shoot ();
		}

		if(distance <= reachDistance){
			currentWayPointID++;
		}

		if(currentWayPointID >= pathtofollow.pathsObject.Count){
			currentWayPointID = pathtofollow.pathsObject.Count-1;
			currentWayPointID = 0;
			gameObject.SetActive (false);
			singleShot = true; // again can single shoot
		}

		//transform.rotation = Quaternion.LookRotation (pathtofollow.pathsObject [currentWayPointID].position);
		//Debug.Log ("current way point ID :"+currentWayPointID);
	}

	void shoot(){
		GameObject bullet = EnemyBulletPooler._Instance.getBullet ((int)EnemyBulletPooler.Enemies.Enemy_02);
		bullet.transform.position = this.transform.position;
		bullet.SetActive (true);
		//Debug.Log (mid);
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

	public void giveDamage(int _dmg){

        Health -= _dmg;

		if(Health<0){
			currentWayPointID = 0;
			gameObject.SetActive(false);

			GameObject explsion = ExplosionPooler._Instance.getExplosion ((int)ExplosionPooler.explosionFabs.enemyExplosion);
			explsion.transform.position = transform.position;
			explsion.SetActive (true);

			Health = initialHealth;
		}
	}


}
