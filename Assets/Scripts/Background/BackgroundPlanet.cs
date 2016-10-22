using UnityEngine;
using System.Collections;

// planet behaviour
public class BackgroundPlanet : MonoBehaviour {


	public float movespeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (Vector3.down * movespeed *Time.deltaTime);
	}

}
