using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int Health;
    [Tooltip("Player bullet damage")]
    public int damage; // player bullet hit damage

    private int initialHealth;
	private int cnt = 0;

	// Use this for initialization
	void Start () {
        initialHealth = Health;
	}
	
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Bullet"){
			//cnt++;
			// coroutine can solve the problem or keep it as a feature 
			giveDamage (damage);
        }
		else if(col.gameObject.tag == "Player"){
			//Debug.Log ("ship");
			giveDamage (Health+10); // destroy
		}
        else if(col.gameObject.tag == "KillBox"){
            Health = initialHealth;
        }
			
		//Debug.Log (cnt);

    } // end 
		

	void giveDamage(int _dmg){
        
        if(Health>0){
            Health -= _dmg;
        }
        else{
			gameObject.SetActive(false);

			GameObject explsion = ExplosionPooler._Instance.getExplosion ((int)ExplosionPooler.explosionFabs.enemyExplosion);
			explsion.transform.position = transform.position;
			explsion.SetActive (true);

			Health = initialHealth;
        }

    }
}
