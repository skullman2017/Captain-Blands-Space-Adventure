using UnityEngine;
using System.Collections;

public class PlanetManager : MonoBehaviour {

	public GameObject obj1;
	public GameObject obj2;
	public float secToWait;

	private GameObject clone;
	private Vector3 spawnPos;
	private bool isAlive1 = false;
	// Use this for initialization
	void Start () {
		// bottom 
		StartCoroutine (waitToSpawn (secToWait));
	}
		
	IEnumerator waitToSpawn(float _secs){
		yield return new WaitForSeconds (_secs);

		spawnPlanet (obj1);

		yield return new WaitForSeconds (_secs * 2);

		spawnPlanet (obj2);
	}

	void spawnPlanet(GameObject _obj){
		spawnPos = Camera.main.ViewportToWorldPoint (new Vector3 (Random.Range(0.1f,0.9f),Random.Range (1.5f,1.7f), 20f));
		clone = Instantiate (_obj, spawnPos, Quaternion.identity) as GameObject;
		clone.transform.parent = this.transform;
	}



} // end class 
