using UnityEngine;
using System.Collections;

public class EnemyBulletSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Invoke ("testPool", 4f);	
	}

	void testPool(){
		
		GameObject go = EnemyBulletPooler._Instance.getBullet ((int)EnemyBulletPooler.Enemies.Enemy_01);
		Debug.Log (go);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
