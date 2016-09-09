using UnityEngine;
using System.Collections;

public class bulletResetPos : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D other){
       // print(other.gameObject.tag);
        if(other.gameObject.tag == "KillBox"){
            //reset bullet position
            print("killbox");
            gameObject.SetActive(false);
            //gameObject.transform.position = spawPos;
        }
    }

}
