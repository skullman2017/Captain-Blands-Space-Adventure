﻿using UnityEngine;
using System.Collections;

// player bullet 
public class bulletResetPos : MonoBehaviour {


    private Rigidbody2D bulletBody;
    [SerializeField]
    private float speed = 350f;

	private Vector2 topRightCorner;

    void Start(){
        bulletBody = GetComponent<Rigidbody2D>();

		topRightCorner = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		topRightCorner.y = topRightCorner.y + 0.5f;
    }


    void FixedUpdate(){
        bulletBody.velocity = Vector2.up * Time.deltaTime * speed;
    }
        

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "KillBox"){
            gameObject.SetActive(false);
        }
        else if(col.tag=="SimpleEnemy"){
            gameObject.SetActive(false);
        }
    }

	void Update(){
		if(transform.position.y > topRightCorner.y){
			//Debug.Log ("bullet out of camera");
			gameObject.SetActive (false);
		}
	}

}
