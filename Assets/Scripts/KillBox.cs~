using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

    private int enemyLayer = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == enemyLayer){
            other.gameObject.SetActive(false); // kill all enemy
            //print("enemy killed");
        }
    }


}
