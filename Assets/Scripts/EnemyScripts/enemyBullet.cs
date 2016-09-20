using UnityEngine;
using System.Collections;

public class enemyBullet : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            //print("collide with player");
            gameObject.SetActive(false);
        }
        else if(col.tag == "KillBox"){
            //print("collide with kill box ");
            gameObject.SetActive(false);
        }
    }
       

    void OnBecameInvisible(){
       // print("bullet out of camera");
       // gameObject.SetActive(false);
    }

    void Update(){
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // bottom left of screen
        if(transform.position.y < min.y){
            gameObject.SetActive(false);
        }
    }

}
