using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class QuiteGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // I dont want to show banner top of the Game Title 

       // AddManager.Instance.showBanner();
	}
	

     void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                Time.timeScale = 0; // pause game
                Application.Quit();
            }
        }
    }

    public void quiteGame()
    {
        Time.timeScale = 0;
        Application.Quit();
    }

}
