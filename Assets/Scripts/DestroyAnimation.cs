using UnityEngine;
using System.Collections;

// used to destroy animation when done 
public class DestroyAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// kill on last frame of animation
    void destroy(){
        GemsSpawner.spawnGems(this.transform.position);
        gameObject.SetActive(false);
        // spawn gems
    }
}
