using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int Health;
    [Tooltip("Player bullet damage")]
    public int damage; // player bullet hit damage

    private int initialHealth;

	// Use this for initialization
	void Start () {
        initialHealth = Health;
	}
	
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Bullet"){
            col.gameObject.SetActive(false);
            giveDamage();
        }
        else if(col.gameObject.tag == "KillBox"){
            Health = initialHealth;
        }
    }

    void giveDamage(){
        
        if(Health>0){
            Health -= damage;
        }
        else{
            gameObject.SetActive(false);
            Health = initialHealth;
        }

    }
}
