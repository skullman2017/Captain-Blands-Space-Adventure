using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // at the beginning player has full health
        transform.localScale = new Vector2(1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
       // if(transform.localScale.x <= 0.01){
           // print("player healt empty");
       // }
	}

    public float giveDamage(float dmg){
        if (transform.localScale.x > 0.01)
        {
            transform.localScale = new Vector2(transform.localScale.x - (dmg * Time.deltaTime), 1f);
        }
        return transform.localScale.x;
    }

}
