using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Enemy_01_Spawner : MonoBehaviour {

    public Transform[] topDownPoints;
    private Enemy_01_Pooler thepool; // return enemy object
    private string[] enemyPtrn = new string[3];
    private int[] theArray;
   
    [HideInInspector]
    public int numOfAvilablePos; // for toptodown enemy

	// Use this for initialization
	void Start () {
        thepool = FindObjectOfType<Enemy_01_Pooler>();

        initalStage();

        StartCoroutine(manageTopDownEnemy(5f));
    }
	
    void initalStage(){
        theArray = new int[topDownPoints.Length];
       
        for(int i=0;i<theArray.Length;i++){
            theArray[i] = i; // the available free position
        }

        enemyPtrn[0] = "TopDown";
        enemyPtrn[1] = "SineWave";
        enemyPtrn[2] = "FollowPattern";
    }

    IEnumerator manageTopDownEnemy(float secs){
        yield return new WaitForSeconds(secs);

        SpawnTopToDown_Enemy();
    }

    void SpawnTopToDown_Enemy(){
        // numOfAvilablePos = 0;

        int rndPos = Random.Range(0, 4);
        int startPos = 0;
        int endPos = 0;

        if (rndPos == 0){
            startPos = 0;
            endPos = 2;
         
        }
        else if(rndPos == 1){
            startPos = rndPos;
            endPos = 3;
        }
        else if(rndPos == 2){
            startPos = rndPos;
            endPos = 4;
        }
        else if(rndPos>2){
            instantiateEnemy(0,1);
            startPos = 3;
            endPos = 4;
        }

        instantiateEnemy(startPos, endPos);


        float rnd = Random.Range(5, 6);
        StartCoroutine(manageTopDownEnemy(rnd));

    }
  
    void instantiateEnemy(int startpos ,int endpos){
        
        for (int i = startpos; i <= endpos; i++)
        {
            GameObject go = thepool.getEnemy_01();
            go.transform.position = topDownPoints[i].position;
            go.SetActive(true);
            numOfAvilablePos -= 1;
        }
    }

	// Update is called once per frame
	void Update () {
        //Debug.Log("num of available position "+numOfAvilablePos);
	}
}
