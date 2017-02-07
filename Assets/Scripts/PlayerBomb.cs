using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour {


    // Use this for initialization
    void Start () {
       
    }


    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Enemy" || col.tag == "EnemyBullet" || col.tag=="Meteor") {
            //col.gameObject.SetActive(false);


            pathFollower go = null;
            EnemyHealth enemyHealth = null;

            go = col.gameObject.GetComponent<pathFollower>(); // here is also pathrotation

            if (go) {
                // for enemy_02 reset initial pathID
                go.giveDamage(100);
                enemyExplosion(col);
                return;
            }
            else if(enemyHealth = col.gameObject.GetComponent<EnemyHealth>()) {
                enemyHealth.giveDamage(100);
                return;
            }
            else {
                col.gameObject.SetActive(false);
                enemyExplosion(col);
            }
        }
    }


   void enemyExplosion(Collider2D col) {
        // using meteor explosion 
        GameObject explosion = ExplosionPooler._Instance.getExplosion(0);
        explosion.transform.position = col.transform.position;
        explosion.SetActive(true);
    }

}
