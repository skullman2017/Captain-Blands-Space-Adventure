using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour {

    private string playerTag = "Player";
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * Time.deltaTime );
	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag==playerTag) {
            this.gameObject.SetActive(false);
        }
    }

}
