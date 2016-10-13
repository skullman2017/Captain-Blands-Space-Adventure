﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_01_Pooler : MonoBehaviour {


    public int amount;
    public int secsTowait;
    [SerializeField]
    private GameObject[] prefabs; // toptodown

    private List<GameObject> EnemyPool = new List<GameObject>();
    private int count; 
    private GameObject enemyHolder;

    // Use this for initialization
	void Start () {
        count = 0;
        enemyHolder = new GameObject("Enemy_01_Holder");
       
        StartCoroutine(runInstance(secsTowait));
	}
	
    void _instantiate(){

        for(int j=0;j<prefabs.Length;j++){
            for(int i=count ;i<amount;i++){
                GameObject clone = Instantiate(prefabs[j], Vector2.up, Quaternion.identity) as GameObject;
                clone.transform.parent = enemyHolder.transform;
                clone.SetActive(false);
               
                EnemyPool.Add(clone);
                break;
            }
        }

    } // end 


    IEnumerator runInstance(float _sec){
        yield return new WaitForSeconds(_sec);
        // create one
        if(count<=amount){
            _instantiate();
            count++;
            StartCoroutine(runInstance(secsTowait));
        }
    }

    /*
     * if failed to return a tag then try for another tag  - call from EnemySpawner 
    */
        public GameObject getEnemy_01(string _tag){
        for(int i=0; i<EnemyPool.Count; i++){
            if(EnemyPool[i].activeInHierarchy == false){
                EnemyPool[i].gameObject.tag = _tag;
                return EnemyPool[i];
            }
        }
/*
        GameObject clone = Instantiate(prefabs, Vector2.up, Quaternion.identity) as GameObject;
        clone.transform.parent = enemyHolder.transform;
        clone.SetActive(false);
        clone.gameObject.tag = _tag;

        EnemyPool.Add(clone);
*/
        return null;
       
    }

}
