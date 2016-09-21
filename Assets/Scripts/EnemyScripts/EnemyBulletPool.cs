using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBulletPool : MonoBehaviour {

    [SerializeField]
    private GameObject enemy1_bullet;
    [SerializeField]
    private int amount;
    private GameObject EnemyBulletHolder;

    private List<GameObject> BulletPool = new List<GameObject>();

	// Use this for initialization
	void Start () {
        EnemyBulletHolder = new GameObject("EnemyBulletHolder");

        for(int i=0;i<amount;i++){
            GameObject clone = Instantiate(enemy1_bullet,Vector2.zero, Quaternion.identity) as GameObject;
            clone.transform.parent = EnemyBulletHolder.transform;
            clone.SetActive(false);

            BulletPool.Add(clone);
        }
	}
	

    public GameObject getBullet(){

        for(int i=0;i<BulletPool.Count;i++){
            if(BulletPool[i].activeInHierarchy == false){
                return BulletPool[i];       
            }    
        }

        GameObject go = Instantiate(enemy1_bullet, Vector2.zero, Quaternion.identity) as GameObject;
        go.transform.parent = EnemyBulletHolder.transform;
        go.SetActive(false);

        BulletPool.Add(go);

        return go;

    } //end 

}
