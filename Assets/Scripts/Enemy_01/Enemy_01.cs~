using UnityEngine;
using System.Collections;

// script for enemy behaviour 
public class Enemy_01 : MonoBehaviour {

    public int Health;
    private int damage = 10;
    public float moveSpeed;

    private float offset;
    private Enemy_01_Spawner thespawner;

	// Use this for initialization
	void Start () {
        offset = transform.position.y;
        thespawner = FindObjectOfType<Enemy_01_Spawner>();
	}
	
	// Update is called once per frame
	void Update () {
        moveTopToDown();
    }


    void moveTopToDown(){
        transform.Translate(Vector2.down * Time.deltaTime*moveSpeed);
    }


    // move like wave 
    void moveSineWave(){
        Vector2 pos = new Vector2(transform.position.x, Mathf.Sin(Time.time*2f)*1f+offset);
        transform.position = pos + Vector2.left * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Bullet"){
            col.gameObject.SetActive(false);
            reduceHealth(damage);
            // Debug.Log("player bullet");
        }
    }

    void reduceHealth(int damage){
        if (Health <= 0)
        {
            gameObject.SetActive(false); 
            thespawner.numOfAvilablePos +=1;
        }
        else
        {
            Health -= damage; 
        }
    }



}
