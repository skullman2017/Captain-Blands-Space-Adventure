﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bulletPooler : MonoBehaviour {

    public GameObject bulletPrefabs; // player bullet 
    public int numOfBullets; // for player bullet 

    public GameObject[] enemyBulletPrefabs; // for enemy bullets
    public int numOfEnemyBullets;

    public List<GameObject> bulletPool = new List<GameObject>(); // player bullet pool
    private List<GameObject> enemyBulletPool = new List<GameObject>(); // enemy bullet pool

 	// Use this for initialization
	void Start () {     

        GameObject objectHolder = new GameObject("BulletHolder");
            
        for(int i=0;i<numOfBullets;i++){
            GameObject clone = Instantiate(bulletPrefabs,Vector2.zero, Quaternion.identity) as GameObject;
            clone.transform.parent = objectHolder.transform;
            clone.SetActive(false);

            bulletPool.Add(clone);
        }

        createEnemyBullets();
	}
	

    void createEnemyBullets(){

        for(int i=0;i<enemyBulletPrefabs.Length;i++){
            for(int j=0;j<numOfEnemyBullets;j++){
                GameObject clone = Instantiate(enemyBulletPrefabs[i], Vector2.zero, Quaternion.identity) as GameObject;
                clone.transform.parent = GameObject.Find("BulletHolder").transform;
                clone.SetActive(false);
                // add them to the pool
                enemyBulletPool.Add(clone);
            }
        }

    }

    public GameObject getEnemyBullet(){

        for(int i=0;i<enemyBulletPool.Count;i++){
            if(enemyBulletPool[i].activeInHierarchy == false){
                return enemyBulletPool[i];
            }
        }

        return null;
    }

	
} // end class 
