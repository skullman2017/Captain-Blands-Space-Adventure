﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 1f;
    private bulletPooler objPooler;

    public float secondsToWait;
    public BulletSpawnPos bulletSpawnPos1; // instantiate position 
    public BulletSpawnPos bulletSpawnPos2;

    private Vector3 spawPos1;
    private Vector3 spawPos2;

    private float accleStartY;

    private AudioSource playerAudioSource;

	// Use this for initialization
	void Start () {
        playerAudioSource = GetComponent<AudioSource>();

        objPooler = FindObjectOfType<bulletPooler>();

        accleStartY = Input.acceleration.y; // mobile 

        // firing autometically 
       // InvokeRepeating("FireBtn",0.5f, secondsToWait);

	}
	

	// Update is called once per frame
	void Update () {
        //float h = CrossPlatformInputManager.GetAxis("Horizontal");
        //float v = CrossPlatformInputManager.GetAxis("Vertical");
	    
        float h = Input.acceleration.x;
        float v = Input.acceleration.y - accleStartY;

        // get the joystick input 
        Vector2 direction = new Vector2(h,v);

        if(direction.sqrMagnitude > 1){
            direction.Normalize();  
        }
            
        // moveplayer
        movePlayer(direction);
        // tap to fire 
        FireBtn();
       
    } // end 

    public void FireBtn(){
        // fire bullets
        if(Input.GetMouseButtonDown(0)){
            //print("fire btn down");
            spawPos1 = bulletSpawnPos1.transform.position; // update the postion 
            spawPos2 = bulletSpawnPos2.transform.position;

            playerAudioSource.Play(); // play fire sfx
            FireBullet();
        }
    }

    void movePlayer(Vector2 dir){
        //transform.Translate(h*Time.deltaTime * moveSpeed ,v*Time.deltaTime * moveSpeed,transform.position.z);
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // return the bottom-left position 
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // return the top-right position

        max.x = max.x - 0.5f; // subtract player sprite half 
        min.x = min.x + 0.5f;

        max.y = max.y - 0.5f;
        min.y = min.y + 0.5f;

        // get the player current position 
        Vector2 playerPos = transform.position; 
        playerPos += dir * moveSpeed * Time.deltaTime; // calculate player new position
        // bound the world
        playerPos.x = Mathf.Clamp(playerPos.x , min.x, max.x);
        playerPos.y = Mathf.Clamp(playerPos.y , min.y, max.y);

        // update player position 
        transform.position = playerPos;
    }


    void FireBullet(){
        int b1 = 0;
        int b2 = 0;


        for(int i=0;i<objPooler.bulletPool.Count;i++){
            if(objPooler.bulletPool[i].activeInHierarchy == false){
                b1 = i;

                for(int j=i+1;j<objPooler.bulletPool.Count; j++){
                    if(objPooler.bulletPool[j].activeInHierarchy == false){
                        b2 = j;
                        break;
                    }    
                } // 
                break;
            }
        }

        //print(b1);
       // print(b2);

        objPooler.bulletPool[b1].transform.position = spawPos1;
        objPooler.bulletPool[b1].SetActive(true);

        objPooler.bulletPool[b2].transform.position = spawPos2;
        objPooler.bulletPool[b2].SetActive(true);

      

    } // end 
        

}
