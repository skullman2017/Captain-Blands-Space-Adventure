using UnityEngine;
using System.Collections;

public class EnemyEventManager : MonoBehaviour {

	// Use this for initialization
	private EnemyBulletPooler thebulletPooler;

	// used for event execution one after another
	public delegate void MyDelegate();
	public static MyDelegate theEventDelegate;

	void Start () {
		thebulletPooler = FindObjectOfType <EnemyBulletPooler> ();	

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
		// enemy_01 shoot straight
		Debug.Log ("initate event B");
	}

}
