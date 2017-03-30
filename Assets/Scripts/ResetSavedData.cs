using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSavedData : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetInt("FLAG") == 0 ) // first time run 
        {
            // set default value 
            PlayerPrefs.SetInt("PLAYER_TOTAL_SCORE", 0);
            PlayerPrefs.SetInt("PLAYTIMES",0);
            PlayerPrefs.SetInt("LASER", 1);
            PlayerPrefs.SetInt("BOMB", 1);

            // set flag false
            PlayerPrefs.SetInt("FLAG", 1);

        }     

    }
	

}
