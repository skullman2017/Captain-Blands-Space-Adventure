using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_01_Pooler : MonoBehaviour {


    public int amount;
    public int secsTowait;
    [SerializeField]
    private GameObject prefabs;
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
        for(int i=count ;i<amount;i++){
            GameObject clone = Instantiate(prefabs, Vector2.up, Quaternion.identity) as GameObject;
            clone.transform.parent = enemyHolder.transform;
            clone.SetActive(false);

            EnemyPool.Add(clone);
            break;
        }
    }


    IEnumerator runInstance(float _sec){
        yield return new WaitForSeconds(_sec);
        // create one
        if(count<=amount){
            _instantiate();
            count++;
            StartCoroutine(runInstance(secsTowait));
        }
    }

    public GameObject getEnemy_01(string _tag){
        for(int i=0; i<EnemyPool.Count; i++){
            if(EnemyPool[i].activeInHierarchy == false && EnemyPool[i].tag == _tag){
                return EnemyPool[i];
            }
        }

        GameObject clone = Instantiate(prefabs, Vector2.up, Quaternion.identity) as GameObject;
        clone.transform.parent = enemyHolder.transform;
        clone.SetActive(false);
        clone.gameObject.tag = _tag;

        EnemyPool.Add(clone);

        return clone;
       
    }

}
