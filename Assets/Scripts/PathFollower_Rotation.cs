using UnityEngine;
using System.Collections;

public class PathFollower_Rotation : MonoBehaviour {


	public float speed;
	public int Health;
	[Tooltip("Player bullet damage")]
	public int damage; // player bullet hit damage
	private int initialHealth;
	private PlayerController theplayer;

    Vector2 dir = Vector2.one;

    // Use this for initialization
    void Start () {
		initialHealth = Health;
    }

	void OnEnable(){
		theplayer = FindObjectOfType <PlayerController> ();
        dir = (theplayer.transform.position - transform.position).normalized;

        enemyRotation();

		//print("Activate");
	}

	
	void OnDisable(){
		theplayer = null;
		//print("Deactivate");
	}

	// Update is called once per frame
	void Update () {
		
        Vector3 tmp = dir * speed * Time.deltaTime;
        transform.position += tmp;

       // enemyRotation();

    }

    private void enemyRotation() {
        // rotation
        Vector2 targetRotation = theplayer.transform.position - transform.position;
        float angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, angle - 269f);
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

	public void giveDamage(int _dmg){
		Health -= _dmg;
		if(Health<0){
			gameObject.SetActive(false);

			GameObject explsion = ExplosionPooler._Instance.getExplosion ((int)ExplosionPooler.explosionFabs.enemyExplosion);
			explsion.transform.position = transform.position;
			explsion.SetActive (true);
			Health = initialHealth;

           // GemsSpawner.spawnMultipleGems(this.transform.position);
		}
	}
}
