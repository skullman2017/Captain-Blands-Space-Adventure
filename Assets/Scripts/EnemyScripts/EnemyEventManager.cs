using UnityEngine;
using System.Collections;


public class EnemyEventManager : MonoBehaviour {


	// Use this for initialization
	private EnemyBulletPooler thebulletPooler;
	private Enemy_01_Spawner theEnemy_01Spawner;
	private MultipleEnemySpawner theEnemySpawner; // multiple enemy spawner

	// used for event execution one after another
	public delegate void MyDelegate(); // delegate signature
	public static MyDelegate theEventDelegate;

	public static bool canFire = false; // used for enemy fire flag

	void Start () {
		thebulletPooler = FindObjectOfType <EnemyBulletPooler> ();	
		theEnemy_01Spawner = FindObjectOfType <Enemy_01_Spawner> ();
		theEnemySpawner = FindObjectOfType <MultipleEnemySpawner> ();

		// stack events here 
		theEventDelegate += initiate_Event_B;

	}
	
	// signal get from the Enemy_01_Spawner
	// get perpare for next enemy
	void createEnemyBullet(){
		thebulletPooler.runCoroutine ();
	}

	 void initiate_Event_B(){
		theEnemy_01Spawner.FireEnemy ();
		// unstack
		theEventDelegate -= initiate_Event_B;
		// stack 
		theEventDelegate += initiate_Event_C;
		/*theEventDelegate += initiate_Event_C_02;*/
	}

	// enemy 02 pattern 
	// get call from Enemy_01_spawner
	void initiate_Event_C(){
		// path following enemy
        // this spawnEnemy will also call Enemy_5 formation follow the chain
		theEnemySpawner.spawnEnemy ();
		theEventDelegate -= initiate_Event_C;
	}

	

}
