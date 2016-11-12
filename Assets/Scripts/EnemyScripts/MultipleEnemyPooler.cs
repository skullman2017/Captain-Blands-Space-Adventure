﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// there are objects to pool
[System.Serializable]
public class EnemyObject{
	public GameObject Object;
	public int Amount;
}

public class MultipleEnemyPooler : MonoBehaviour {

	public static MultipleEnemyPooler _Instance;
	public EnemyObject[] _prefabs; // prefabs, store the objects info
	private List<GameObject>[] thePool; // array of list 

	// used for enemy ID to getEnemyBullets
	public enum Enemies {
		Enemy_02
	};


	[Range(2,100)]
	public int secsTowait;

	void Awake(){
		_Instance = this;
	}

	// Use this for initialization
	void Start () {
		Invoke ("runCoroutine",secsTowait);
	}

	void runCoroutine(){
		StartCoroutine (createPool ());
	}

	IEnumerator createPool(){
		GameObject clone;
		// created an array of type list<GameObjetc>
		thePool = new List<GameObject>[_prefabs.Length]; 

		for(int count=0; count < _prefabs.Length; count++){
			// here created list in each position of array
			thePool [count] = new List<GameObject> ();

			// now add gameobjects to the list 
			for(int i=0;i<_prefabs[count].Amount;i++){
				clone = Instantiate (_prefabs [count].Object, Vector2.zero, Quaternion.identity) as GameObject;
				clone.SetActive (false);
				clone.transform.parent = this.transform;
				thePool [count].Add (clone);

				// wait for 1 secs in each creation
				yield return new WaitForSeconds (0.5f);
			}
		}

	} // end method 


	// give id 
	// pass param like 
	/*
	getBullet((int)Enemies.Enemy_01);
	*/
	public GameObject getEnemy(int id){

		for(int count = 0; count < thePool[id].Count; count++){
			if(thePool[id][count].activeInHierarchy == false){
				return thePool [id] [count];
			}
		}

		// if dont return anything then create a object and add to pool
		GameObject clone = Instantiate (_prefabs [id].Object, Vector2.zero, Quaternion.identity) as GameObject;
		clone.SetActive (false);
		clone.transform.parent = this.transform;
		thePool [id].Add (clone);

		return clone;
	}

}
