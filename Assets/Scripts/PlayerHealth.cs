using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public Image healthBar;

	// Use this for initialization
	void Start () {

        if(healthBar!=null){
            healthBar.fillAmount = 1f;
        }
        else{
            GameObject HB = GameObject.FindGameObjectWithTag("UICanvas");
            healthBar = HB.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
        }
	}

    public float playerDamage(float dmg){
        healthBar.fillAmount -= dmg;
        
        return healthBar.fillAmount;
    }


}
