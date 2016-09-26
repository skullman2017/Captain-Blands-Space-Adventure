using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeteorPooler : MonoBehaviour {

    public int amount;
    [SerializeField]
    private GameObject[] meteorfabs;
    private List<GameObject> MeteorPool = new List<GameObject>();
	// Use this for initialization
	void Start () {
                    
        GameObject meteorHolder = new GameObject("MeteorHolder");

        for(int i=0;i<meteorfabs.Length;i++){
            for(int j=0;j<amount;j++){  
                GameObject go = Instantiate(meteorfabs[i], Vector2.zero, Quaternion.identity) as GameObject;
                go.transform.parent = meteorHolder.transform;
                go.SetActive(false);

                MeteorPool.Add(go);
            }
        }

	}
	
    public GameObject getMeteor(){

        for(int i=0;i<MeteorPool.Count; i++){
            if(MeteorPool[i].activeInHierarchy == false){
                return MeteorPool[i];
            }    
        }

        return null;

    }

}
