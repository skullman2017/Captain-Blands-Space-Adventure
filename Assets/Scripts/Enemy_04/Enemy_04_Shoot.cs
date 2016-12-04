using UnityEngine;
using System.Collections;

public class Enemy_04_Shoot : MonoBehaviour {

	public GameObject bullet;
	public float shootdelay;
	private bool readyShoot = true;


	// Use this for initialization
	void Start () {
		Invoke ("shoot", shootdelay);
	}


	void shoot(){
		Instantiate (bullet, transform.position,transform.rotation);
		Invoke ("shoot",shootdelay);
	}
}
