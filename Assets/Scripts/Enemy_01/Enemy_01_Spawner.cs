using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Enemy_01_Spawner : MonoBehaviour {

    public float secsToWait;
   
    public Transform[] topDownPos;
    public Transform[] leftPos; // left to right
    public Transform[] rightPos; // right to left

    private Enemy_01_Pooler thepooler;

    private int eventID = 0;
    private bool isRunning = false;

    public bool ptr1 = false;

    void Start(){
        thepooler = FindObjectOfType<Enemy_01_Pooler>();

    }

    public void StartSpawn(){
        InvokeRepeating("cancelCoroutine", 2f,2f);
        StartCoroutine(Event_A(secsToWait));
    }

    void cancelCoroutine(){
        if(Time.timeSinceLevelLoad > 50f){
            StopAllCoroutines();
            CancelInvoke();
            //Debug.Log("stopped");
        }
    }

    IEnumerator Event_A(float _secs){
        // toptodown, lefttoright and righttoleft no fire
        yield return new WaitForSeconds(_secs);
        TopToDown();
        yield return new WaitForSeconds(_secs*2);
        LefttoRight();
        yield return new WaitForSeconds(_secs);
        RightToLeft();

        // repeat 
        StartSpawn();
    }
        

    void TopToDown(){
        int rnd = Random.Range(0, topDownPos.Length);

        int _start = 0;
        int _end = 0;

        if(rnd == 0){
            _start = 0;
            _end = 2;
        }
        else if(rnd == 1){
            _start = 1;
            _end = 3;
        }
        else if(rnd == 2){
            _start = 2;
            _end = 4;
        }
        else if(rnd > 2){
            _start = 0;
            _end = 1;
            // call 
            _instantiate(_start, _end, "TopToDown", topDownPos);
            _start = 3;
            _end = 4;
        }

        // call
        _instantiate(_start, _end, "TopToDown", topDownPos);
    }

    void LefttoRight(){
       // Debug.Log("left to right");
        _instantiate(0,2, "MoveLeftToRight", leftPos);
    }

    void RightToLeft(){
        _instantiate(0,2, "MoveRightToLeft", rightPos);  
    }

    void _instantiate(int start, int end, string _tag, Transform[] _spawnPos){

        for(int i=start; i<=end;i++){
            GameObject go = thepooler.getEnemy_01(_tag);
            if (go != null)
            {
                go.transform.position = _spawnPos[i].position;
                go.SetActive(true);
            }
        }

    }


    void Update(){
       
    }

}// end class 
