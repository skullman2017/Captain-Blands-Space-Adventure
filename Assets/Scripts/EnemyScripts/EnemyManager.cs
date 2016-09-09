using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    private EnemyPool enemypool;
    public Transform[] paths;
    public float secToWait;
    private GameObject enemyClone;
    public int CurrentPos;
    public float moveSpeed;
    private float reachDistance = 1f;
    public Transform initialPosition; // initial spawn position

	// Use this for initialization
	void Start () {
        enemypool = FindObjectOfType<EnemyPool>();

        InvokeRepeating("PoolEnemy",1f,secToWait);
	}
	
    void PoolEnemy(){

        //Debug.Log(enemypool.enemyPool.Count);

        for(int i=0;i<enemypool.enemyPool.Count;i++){
            if(enemypool.enemyPool[i].activeInHierarchy == false){
                enemypool.enemyPool[i].transform.position = initialPosition.position;
                enemypool.enemyPool[i].SetActive(true);
                enemyClone = enemypool.enemyPool[i];
                break;
            }
        }
    }

	// Update is called once per frame
	void Update () {

        if (enemyClone != null)
        {
            float distance = Vector2.Distance(paths[CurrentPos].position, enemyClone.transform.position);
            //Debug.Log(distance);
            enemyClone.transform.position = Vector2.Lerp(enemyClone.transform.position, paths[CurrentPos].position, Time.deltaTime * moveSpeed);

            if(distance <= reachDistance){
                CurrentPos++;
            }
            if(CurrentPos >= paths.Length){
                CurrentPos = 0;
            }
        }
	}
}
