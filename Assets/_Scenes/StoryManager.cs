using UnityEngine;
using System.Collections;

public class StoryManager : MonoBehaviour {

	public GameObject fadeScreen;

	// Use this for initialization
	void Start () {
		if(fadeScreen.activeInHierarchy){
			fadeScreen.SetActive (false);
		}
	}
	
	public void fadeIn(){
		fadeScreen.SetActive (true);
	}

}
