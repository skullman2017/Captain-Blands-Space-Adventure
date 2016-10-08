using UnityEngine;
using System.Collections;

public class Enemy_01_Spawner : MonoBehaviour {

    public Transform[] spawnPoints;
    private Enemy_01_Pooler thepool;

	// Use this for initialization
	void Start () {
        thepool = FindObjectOfType<Enemy_01_Pooler>();

        StartCoroutine(liveEnemy(6f));
	}
	

    IEnumerator liveEnemy(float _secs){
        yield return new WaitForSeconds(_secs);

        spawnEnemy();
    }

    void spawnEnemy(){
        GameObject enemy = thepool.getEnemy_01();
        enemy.transform.position = spawnPoints[0].position;
        enemy.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
