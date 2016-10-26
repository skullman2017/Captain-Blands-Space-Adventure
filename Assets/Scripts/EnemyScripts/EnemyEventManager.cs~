using UnityEngine;
using System.Collections;

public class EnemyEventManager : MonoBehaviour {

	// Use this for initialization
	private EnemyBulletPooler thebulletPooler;

	void Start () {
		thebulletPooler = FindObjectOfType <EnemyBulletPooler> ();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void createEnemyBullet(){
		thebulletPooler.runCoroutine ();
	}

}
