using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

    private int enemyLayer = 10;
	private int enemyBulletLayer = 11;
	// Use this for initialization
	void Start () {
	
	}
	
	
    void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.layer == enemyLayer || other.gameObject.layer == enemyBulletLayer){
            other.gameObject.SetActive(false); // kill all enemy and enemy bullet
            //print("enemy killed");
        }
    }


}
