using UnityEngine;
using System.Collections;

public class bulletResetPos : MonoBehaviour {


    private Rigidbody2D bulletBody;

    void Start(){
        bulletBody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate(){
        bulletBody.velocity = Vector2.up * Time.deltaTime * 300f;
    }
        

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "KillBox"){
            gameObject.SetActive(false);
        }
        else if(col.tag == "SimpleEnemy"){
            gameObject.SetActive(false);
        }
    }

  

}
