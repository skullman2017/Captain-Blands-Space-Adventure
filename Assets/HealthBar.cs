using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public float initi;
    //public  float damage;
	// Use this for initialization
	void Start () {
        initi = 1f;
        transform.localScale = new Vector2(1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        /*if(transform.localScale.x <=0){
           // print("no health ");
            gameObject.SetActive(false);
        }*/
	}

    public float giveDamage(float damage){
        //damage = damage / 100;

        transform.localScale = new Vector2( transform.localScale.x - (damage * Time.deltaTime), transform.localScale.y);
        return transform.localScale.x;
    }

}
