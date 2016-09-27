using UnityEngine;
using System.Collections;

public class Meteors : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Bullet"){
            other.gameObject.SetActive(false);
        }
        //Debug.Log(other.name);
    }


}
