using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bulletPooler : MonoBehaviour {

    public GameObject bulletPrefabs;
    public int numOfBullets;

    public List<GameObject> bulletPool = new List<GameObject>();

	// Use this for initialization
	void Start () {     

        GameObject objectHolder = new GameObject("BulletHolder");
            
        for(int i=0;i<numOfBullets;i++){
            GameObject clone = Instantiate(bulletPrefabs,Vector2.zero, Quaternion.identity) as GameObject;
            clone.transform.parent = objectHolder.transform;
            clone.SetActive(false);

            bulletPool.Add(clone);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
