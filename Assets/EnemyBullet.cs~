using UnityEngine;
using System.Collections;

public class enemyBullet : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            print("collide with player");
            gameObject.SetActive(false);
        }
    }

}
