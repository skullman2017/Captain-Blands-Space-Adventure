using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionPooler : MonoBehaviour {


    public GameObject explosionfabs;
    public int numOfAmout;
    private GameObject objectHolder;

    private List<GameObject> ObjectPool = new List<GameObject>();
	// Use this for initialization
	void Start () {
	    
         objectHolder = new GameObject("ExplosionHolder");

        for(int i=0;i<numOfAmout;i++){
            GameObject clone = Instantiate(explosionfabs,Vector2.zero, Quaternion.identity) as GameObject;
            clone.transform.parent = objectHolder.transform;
            clone.SetActive(false);

            ObjectPool.Add(clone);
        }

	}
	
    public GameObject getExplosion(){

        for(int i=0;i<ObjectPool.Count;i++){
            if(ObjectPool[i].activeInHierarchy == false){
                return ObjectPool[i];
            }   
        }

        GameObject go = Instantiate(explosionfabs, Vector2.zero, Quaternion.identity) as GameObject;
        go.transform.parent = objectHolder.transform;
        go.SetActive(false);

        ObjectPool.Add(go);

        return go;
    }

	
} // end class 









