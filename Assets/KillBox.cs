using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Bullet"){
            //print("enemy bullet");
            other.gameObject.SetActive(false);
        }

    }

}
