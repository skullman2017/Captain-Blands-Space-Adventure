using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void destroy() {
        GemsSpawner.spawnGems(this.transform.position);
        gameObject.SetActive(false);
        // spawn gems for enemy 
    }
}
