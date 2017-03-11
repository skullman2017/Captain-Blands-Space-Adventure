using UnityEngine;

public class PlayerBomb : MonoBehaviour {

    // Use this for initialization
    void Start () {
       
    }


    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Enemy" || col.tag == "EnemyBullet" || col.tag=="Meteor") {
            //col.gameObject.SetActive(false);


            pathFollower go = null; // enemy 
            EnemyHealth go1 = null; // enemy 
            PathFollower_Rotation go2 = null;

            if (go = col.gameObject.GetComponent<pathFollower>()) {
                // for enemy_02 reset initial pathID
                go.giveDamage(150);
                return;
            }
            else if(go1 = col.gameObject.GetComponent<EnemyHealth>()) {
                go1.giveDamage(150);
                return;
            }
            else if (go2 = col.gameObject.GetComponent<PathFollower_Rotation>()) {
                go2.giveDamage(500);
            }
            else if(col.tag == "Meteor") {
                col.gameObject.SetActive(false);
                enemyExplosion(col);
              //  GemsSpawner.spawnGems(offset);
                return;
            }
            else {
               // print("bullet");
                col.gameObject.SetActive(false);
                //enemyExplosion(col);
            }
        }


        if(col.gameObject.tag=="Boss"){
         //   print(col.gameObject);
            EnemyHealth eH = col.gameObject.GetComponent<EnemyHealth>();
            float dmg = 250f;
            eH.giveDamage(dmg);
        }

    }


   void enemyExplosion(Collider2D col) {
        // using meteor explosion 
        GameObject explosion = ExplosionPooler._Instance.getExplosion(0);
        explosion.transform.position = col.transform.position;
        explosion.SetActive(true);
    }

}
