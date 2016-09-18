using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPoolManager : MonoBehaviour {

    public GameObject[] enemyFabs;
    public int amount;

    private List<GameObject> EnemyPool = new List<GameObject>();
    private GameObject EnemyHolder;

	// Use this for initialization
	void Start () {
        EnemyHolder = new GameObject("EnemyHolder");

        for(int i=0;i<enemyFabs.Length;i++){
            for(int j=0;j<amount;j++){
                GameObject go = Instantiate(enemyFabs[i], Vector2.zero, Quaternion.identity) as GameObject;
                go.transform.parent = EnemyHolder.transform;
                go.SetActive(false);
                // add to list
                EnemyPool.Add(go);
            }    
        }

	}
	
	// pass the enemytag 
    public GameObject getEnemy(string tag){
        for(int i=0;i<EnemyPool.Count;i++){
            if(EnemyPool[i].activeInHierarchy == false && EnemyPool[i].tag == tag){
                return EnemyPool[i];
            }
        }

        GameObject clone = null;

        for(int i=0; i<enemyFabs.Length; i++){
            if(enemyFabs[i].tag == tag){
                clone = Instantiate(enemyFabs[i], Vector2.zero, Quaternion.identity) as GameObject;
                clone.transform.parent = EnemyHolder.transform;
                clone.SetActive(false);
                break;
            }
        }

        EnemyPool.Add(clone);
        return clone;

    }

} // end class 
