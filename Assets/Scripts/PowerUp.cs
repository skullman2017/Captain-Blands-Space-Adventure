using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour {

    
    private RectTransform laser;
    private RectTransform bomb;


	// Use this for initialization
	void Start () {
        laser = GameObject.FindGameObjectWithTag("laserFill").GetComponent<RectTransform>();

        bomb = GameObject.FindGameObjectWithTag("bombFill").GetComponent<RectTransform>();
	}


    // only laser up here 
    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            laser.localScale = new Vector3(laser.localScale.x, laser.localScale.y + 0.04f, laser.localScale.z);

            if (laser.localScale.y >= 1.99f) {
                GameObject.FindObjectOfType<PowerButtonManager>().laserUp(1);
                laser.localScale = new Vector3(laser.localScale.x , 0.1f, laser.localScale.z);
            }
        }
    }

}
