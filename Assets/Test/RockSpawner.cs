using UnityEngine;
using System.Collections;

public class RockSpawner : MonoBehaviour {

    private SpaceRockPool therockpool;

	// Use this for initialization
	void Start () {

        therockpool = FindObjectOfType<SpaceRockPool>();

        InvokeRepeating("rocksIns", 2f , 2f);  	
	}

    void rocksIns(){
        GameObject rock = therockpool.getRocks();
        if(rock != null){
            rock.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
