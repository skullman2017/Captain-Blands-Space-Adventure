using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceRockPool : MonoBehaviour {

    public GameObject rockFab;
    public int amout;

    private List<GameObject> RockPool = new List<GameObject>();
    private Vector2 spawPos;
	// Use this for initialization
	void Start () {

        spawPos = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        for(int i=0;i<amout;i++){
            GameObject clone = Instantiate(rockFab, spawPos, Quaternion.identity) as GameObject;
            clone.SetActive(false);

            RockPool.Add(clone);
        }    
	}

    public GameObject getRocks(){

        for(int i=0;i<RockPool.Count;i++){
            if(RockPool[i].activeInHierarchy == false){
                return RockPool[i];
            }
        }
            
        return null;
    }
	
	
}
