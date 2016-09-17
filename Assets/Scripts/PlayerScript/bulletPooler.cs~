using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bulletPooler : MonoBehaviour {

    public GameObject bulletPrefabs; // player bullet 
    public int numOfBullets; // for player bullet 
    public List<GameObject> bulletPool = new List<GameObject>(); // player bullet pool

 	// Use this for initialization
	void Start () {     

        GameObject objectHolder = new GameObject("PlayerBulletHolder");
            
        for(int i=0;i<numOfBullets;i++){
            GameObject clone = Instantiate(bulletPrefabs,Vector2.zero, Quaternion.identity) as GameObject;
            clone.transform.parent = objectHolder.transform;
            clone.SetActive(false);

            bulletPool.Add(clone);
        }

     
	}
	
	
} // end class 
