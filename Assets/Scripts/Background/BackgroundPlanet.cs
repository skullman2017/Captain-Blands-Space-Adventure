using UnityEngine;
using System.Collections;

// planet behaviour
public class BackgroundPlanet : MonoBehaviour {


	public float movespeed;
	private Vector3 outOfCamera;

	// Use this for initialization
	void Start () {
		outOfCamera =  Camera.main.ViewportToWorldPoint (new Vector2 (1,-0.4f));	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (Vector3.down * movespeed *Time.deltaTime);
	}

	void Update(){
		if(transform.position.y < outOfCamera.y){
			gameObject.SetActive (false);
			resetPos ();
		}
	}

	void resetPos(){
		transform.position =  Camera.main.ViewportToWorldPoint (new Vector3 (Random.Range(0.1f,0.9f),Random.Range (1.5f,1.7f), 20f));
		gameObject.SetActive (true);

		//Debug.Log ("resetpos");
	}

}
