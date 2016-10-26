using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Enemy_01_Spawner : MonoBehaviour {

    [Range(60,120)] // debuging purpose min value will be 60
    public float _eventTime;

	[Tooltip("Seconds to wait to start Spawning")]
    public float secsToWait;

	[Tooltip("random max and min to spawn")]
	public float max;
	public float min;
	private bool flag = false;
    public Transform[] topDownPos;

    private Enemy_01_Pooler thepooler;
    private int lastRnd;

	private EnemyEventManager theEventManager;

    void Start(){
        lastRnd = Random.Range(0, topDownPos.Length-1);

        thepooler = FindObjectOfType<Enemy_01_Pooler>();
		theEventManager = FindObjectOfType <EnemyEventManager> ();
    }

    // signal come from EnemeyPooler when all the object creation done
    public void StartSpawn(){
        
		//Debug.Log ("start co : "+Time.time);
        StartCoroutine(Event_A(secsToWait));
    }
        
  
    IEnumerator Event_A(float _secs){

		if (Time.timeSinceLevelLoad < _eventTime) { // this is time the event will be called 
			if (flag == false) {
				yield return new WaitForSeconds (_secs);
				flag = true;
			}
			else{
				yield return new WaitForSeconds (Random.Range (max, min));
			}
			TopToDown ();

			// repeat 
			StartSpawn ();
		} // end if 
		else {
			//StopCoroutine (Event_A ());
			Debug.Log ("Event A done initiate event 2");

			// call eventManage to preapare for firing enemy
			theEventManager.SendMessage ("createEnemyBullet");
		}
    }


    int UniqueRandomInt(int min, int max){
        int newRnd = Random.Range(min, max);

        while (true)
        {
            if (newRnd != lastRnd)
            {
                //Debug.Log("newRnd : "+newRnd);
                return newRnd;
            }
            else
            {
                newRnd = Random.Range(min, max);      
            }
        }

    } // end 

    void TopToDown(){
        
        int rnd = UniqueRandomInt(0, topDownPos.Length-1);
        lastRnd = rnd;
       
        //print(rnd);
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
        else if(rnd == 3){
            _start = 0;
            _end = 1;
            // call 
            _instantiate(_start, _end, topDownPos);
            _start = 3;
            _end = 4;
        }
        else{
            _start = 0;
            _end = 3;
        }

       
        _instantiate(_start, _end, topDownPos);
    }
        

    void _instantiate(int start, int end, Transform[] _spawnPos){

        for(int i=start; i<=end;i++){
            GameObject go = thepooler.getEnemy_01();
            if (go != null)
            {
                go.transform.position = _spawnPos[i].position;
                go.SetActive(true);
            }
        }

    }


    void Update(){
		
		//Debug.Log ("Time since level load : "+Time.timeSinceLevelLoad);
    }

}// end class 
