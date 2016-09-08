using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    private EnemyPool enemypool;
    public Transform[] paths;
	// Use this for initialization
	void Start () {
        enemypool = FindObjectOfType<EnemyPool>();

        spawEnemy();
	}
	
    void spawEnemy(){

        for(int i=0;i<enemypool.enemyPool.Count;i++){
            if(enemypool.enemyPool[i].activeInHierarchy == false){
                enemypool.enemyPool[i].SetActive(true);
                break;
            }
        }

    }

	// Update is called once per frame
	void Update () {
	
	}
}
