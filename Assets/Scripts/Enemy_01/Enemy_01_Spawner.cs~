using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Enemy_01_Spawner : MonoBehaviour {

    [Range(60,120)] // debuging purpose min value will be 60
    public float _eventTime;
    public float secsToWait;
   
    public Transform[] topDownPos;
    public Transform[] leftPos; // left to right
    public Transform[] rightPos; // right to left

    private Enemy_01_Pooler thepooler;
   

    void Start(){
        thepooler = FindObjectOfType<Enemy_01_Pooler>();
    }

    // signal come from EnemeyPooler when all the object creted done
    public void StartSpawn(){
        
        StartCoroutine(Event_A(secsToWait));

    }
        
  
    IEnumerator Event_A(float _secs){

        if (Time.timeSinceLevelLoad < _eventTime) // this is time the event will be called 
        {
       
            int rnd = Random.Range(1, 3);

            if (rnd == 1) // 1 2 3
            {
                yield return new WaitForSeconds(_secs);
                TopToDown();
                yield return new WaitForSeconds(_secs);
                LefttoRight();
                yield return new WaitForSeconds(_secs);
                RightToLeft();
            }
            else if (rnd == 2) // 2 1 3
            {
                yield return new WaitForSeconds(_secs);
                LefttoRight();
                yield return new WaitForSeconds(_secs);
                TopToDown();
                yield return new WaitForSeconds(_secs);
                RightToLeft();
            }
            else if (rnd == 3) // 3 1 2
            {
                yield return new WaitForSeconds(_secs);
                RightToLeft();
                yield return new WaitForSeconds(_secs);
                TopToDown();
                yield return new WaitForSeconds(_secs);
                LefttoRight();
            }


            // repeat 
            StartSpawn();
        } // end if 
        //Debug.Log("co1");
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
        //Debug.Log("Time delta  "+Time.time);
    }

}// end class 
