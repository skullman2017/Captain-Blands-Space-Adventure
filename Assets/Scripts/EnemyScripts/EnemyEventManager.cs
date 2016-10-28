using UnityEngine;
using System.Collections;

public class EnemyEventManager : MonoBehaviour {

	// Use this for initialization
	private EnemyBulletPooler thebulletPooler;
	private Enemy_01_Spawner theEnemy_01Spawner;

	// used for event execution one after another
	public delegate void MyDelegate(); // delegate signature
	public static MyDelegate theEventDelegate;

	public static bool canFire = false; // used for enemy fire flag

	void Start () {
		thebulletPooler = FindObjectOfType <EnemyBulletPooler> ();	
		theEnemy_01Spawner = FindObjectOfType <Enemy_01_Spawner> ();

		// stack events here 
		theEventDelegate += initiate_Event_B;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// signal get from the Enemy_01_Spawner
	void createEnemyBullet(){
		thebulletPooler.runCoroutine ();
	}

	 void initiate_Event_B(){
		//Debug.Log ("fire bullets");
		theEnemy_01Spawner.FireEnemy ();
	}

}
