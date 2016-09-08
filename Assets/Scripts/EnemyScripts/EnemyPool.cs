using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour {

    public GameObject enemyPrefab;
    public int numOfEnemy;
    public Transform initPos;
    public List<GameObject> enemyPool = new List<GameObject>();

    // Use this for initialization
    void Awake () {     

        GameObject objectHolder = new GameObject("EnemyHolder");

        for(int i=0;i<numOfEnemy;i++){
            GameObject clone = Instantiate(enemyPrefab ,Vector2.zero, Quaternion.identity) as GameObject;
            clone.transform.parent = objectHolder.transform;
            clone.transform.position = initPos.position; // initial position at the top of the camera
            clone.SetActive(false);

            enemyPool.Add(clone);
        }
    }
}
