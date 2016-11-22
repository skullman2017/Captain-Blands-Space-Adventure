using UnityEngine;
using System.Collections;
using System;

public class CameraEffect : MonoBehaviour {

	private Camera thecamera;
	private bool flag = false;
	public GameObject theStoryManager;

	// Use this for initialization
	void Start () {
		thecamera = GetComponent <Camera> ();

		StartCoroutine (zoomOut ());
	}

	IEnumerator zoomOut(){
		yield return new WaitForSeconds (1f);
		flag = true;
		yield return new WaitForSeconds (4f);
		theStoryManager.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		if (thecamera.transform.position.x > -4.6f && flag == true) {
			thecamera.transform.Translate (Vector2.left * Time.deltaTime);
			//thecamera.orthographicSize -= (float) Math.Round ((double) 0.2f * Time.deltaTime, 2) ;
			//thecamera.orthographicSize -= 0.1f * Time.smoothDeltaTime;
		}
	}

}
