using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSavedData : MonoBehaviour {

	// Use this for initialization
	void Start () {

       // reset();

        if (PlayerPrefs.GetInt("FLAG") == 0 ) // first time run 
        {
            // set default value 
            PlayerPrefs.SetInt("PLAYER_TOTAL_SCORE", 0);
           
            PlayerPrefs.SetInt("LASER", 0); // bought bomb 
            PlayerPrefs.SetInt("BOMB", 0); // bought 

            PlayerPrefs.SetInt("CURRENT_LASER", 1);
            PlayerPrefs.SetInt("CURRENT_BOMB", 1);


            // set flag false
            PlayerPrefs.SetInt("FLAG", 1);

        }


    }

    void reset()
    {
        // set default value 
        PlayerPrefs.SetInt("PLAYER_TOTAL_SCORE", 1200);

        PlayerPrefs.SetInt("LASER", 0); // bought bomb 
        PlayerPrefs.SetInt("BOMB", 0); // bought 

        PlayerPrefs.SetInt("CURRENT_LASER", 1);
        PlayerPrefs.SetInt("CURRENT_BOMB", 1);
    }
	

}
