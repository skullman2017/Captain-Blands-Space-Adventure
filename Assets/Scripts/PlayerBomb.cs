using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Enemy" || col.tag == "EnemyBullet" || col.tag=="Meteor") {
            col.gameObject.SetActive(false);
     
            // using meteor explosion 
            GameObject explosion = ExplosionPooler._Instance.getExplosion(0);
            explosion.transform.position = col.transform.position;
            explosion.SetActive(true);
           // Debug.Log("killed by bomb");
        }
    }

}
