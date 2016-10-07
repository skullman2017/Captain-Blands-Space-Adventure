using UnityEngine;
using System.Collections;

public class Enemy_01 : MonoBehaviour {

    public int Health;
    private int damage = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Bullet"){
            col.gameObject.SetActive(false);
            reduceHealth(damage);
            // Debug.Log("player bullet");
        }
    }

    void reduceHealth(int damage){
        if (Health <= 0)
        {
            //gameObject.SetActive(false);    
        }
        else
        {
            Health -= damage; 
        }
    }

}
