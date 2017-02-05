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
            go = col.gameObject.GetComponent<pathFollower>(); // here is also pathrotation

            if(go){
                // for enemy_02 reset initial pathID
                go.giveDamage(100);
            }
            else {
                col.gameObject.SetActive(false);
            }

            // using meteor explosion 
            GameObject explosion = ExplosionPooler._Instance.getExplosion(0);
            explosion.transform.position = col.transform.position;
            explosion.SetActive(true);
            
            GemsSpawner.spawnGems(col.gameObject.transform.position);
        }
    }

}
