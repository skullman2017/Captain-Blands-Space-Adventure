using UnityEngine;
using System.Collections;

public class PathFollower_Rotation : MonoBehaviour {


	private PathEditor pathtofollow;

	private int currentWayPointID = 0;
	public float speed;
	private float reachDistance = 0.1f;
	private float rotationSpeed = 5f;
	public string pathName = "Path 1";

	public int Health;
	[Tooltip("Player bullet damage")]
	public int damage; // player bullet hit damage

	[Range(2,10)]
	public int repeatRate;

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

		// shoot 
		InvokeRepeating ("shoot",2f,repeatRate);
	}

	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance(pathtofollow.pathsObject[currentWayPointID].position, transform.position);
		transform.position = Vector2.MoveTowards(transform.position, pathtofollow.pathsObject[currentWayPointID].position, Time.deltaTime * speed);

		// rotation
		Vector2 targetRotation = theplayer.transform.position - this.transform.position; // just awsome
		float angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, angle-269f);


		if(distance <= reachDistance){
			currentWayPointID++;
		}

		if(currentWayPointID >= pathtofollow.pathsObject.Count){
			currentWayPointID = pathtofollow.pathsObject.Count-1;
			currentWayPointID = 0;
			gameObject.SetActive (false);
		}

	}
		

	void shoot(){
		if (this.gameObject.activeInHierarchy) {
			//Debug.Log ("fire");
			for (int i = 1; i <= 3; i++) {
				GameObject bullet = EnemyBulletPooler._Instance.getBullet ((int)EnemyBulletPooler.Enemies.Enemy_03);
				bullet.transform.position = this.transform.position;
				bullet.transform.Rotate (0,0,this.transform.rotation.z);
				bullet.SetActive (true);
			}
		}
		//Debug.Log ("not fire");
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Bullet"){
			//col.gameObject.SetActive (false);
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
