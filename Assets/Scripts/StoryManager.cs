using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour {

    FadeScreen mainCamera;
    public static bool skipped = false;

	// Use this for initialization
	void Start () {
        
	}
	
    public void skipScene() {
        if (skipped == false) {
            skipped = true;
            Camera.main.SendMessage("fadeIn");
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
