using UnityEngine;
using System.Collections;

// script for enemy behaviour 
public class Enemy_01 : MonoBehaviour {


    public float moveSpeed;
    private float offset;
    
	// Use this for initialization
	void Start () {
        offset = transform.position.y;
     
	}
				

	// Update is called once per frame
	void Update () {
        /* // TODO : check aganist tag may cause problem find another way to slove this 
        if(gameObject.tag == "TopToDown"){
            moveTopToDown();
        }
        else if(gameObject.tag == "MoveLeftToRight"){
            moveLeftToRight();        
        }
        else if(gameObject.tag == "MoveRightToLeft"){
            moveRightToLeft();
        }*/
        moveTopToDown(); // only move top to down
    }

   
    void moveTopToDown(){
        transform.Translate(Vector2.down * Time.deltaTime*moveSpeed);
    }
        
    // move like wave 
    void moveSineWave(){
        Vector2 pos = new Vector2(transform.position.x, Mathf.Sin(Time.time*2f)*1f+offset);
        transform.position = pos + Vector2.left * Time.deltaTime;
    }
		
  
}
