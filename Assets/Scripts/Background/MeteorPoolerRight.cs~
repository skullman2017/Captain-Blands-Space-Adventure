using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeteorPoolerRight : MonoBehaviour {

    public int amount;
    [SerializeField]
    private GameObject[] meteorfabs;
    private List<GameObject> MeteorPool = new List<GameObject>();
    // Use this for initialization
    void Start () {

        GameObject meteorHolder = new GameObject("MeteorHolderRight");

        for(int i=0;i<meteorfabs.Length;i++){
            for(int j=0;j<amount;j++){  
                GameObject go = Instantiate(meteorfabs[i], Vector2.zero, Quaternion.identity) as GameObject;
                go.transform.parent = meteorHolder.transform;
                go.SetActive(false);

                MeteorPool.Add(go);
            }
        }

        shufflelist();
        //print("count "+MeteorPool.Count);

    }

    public GameObject getMeteor(){

        // shuffle list
        //shufflelist();


        for(int i=0;i<MeteorPool.Count; i++){
            if(MeteorPool[i].activeInHierarchy == false){
                return MeteorPool[i];
            }    
        }

        return null;

    }

    private void shufflelist(){

        for(int i=MeteorPool.Count-1; i>0; i-- ){
            int rnd = Random.Range(0, i);
            //Debug.Log("rand "+rnd);
            GameObject tmp = MeteorPool[i];
            MeteorPool[i] = MeteorPool[rnd];
            MeteorPool[rnd] = tmp;
        }
    }

}
