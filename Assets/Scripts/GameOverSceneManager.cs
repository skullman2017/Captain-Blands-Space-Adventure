using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneManager : MonoBehaviour {

    public TextManager textManager;

	// Use this for initialization
	void Start () {
        StartCoroutine(startStory());
	}
	
    IEnumerator startStory()
    {
        yield return new WaitForSeconds(2f);

        textManager.startDialogue();
    }
	
}
