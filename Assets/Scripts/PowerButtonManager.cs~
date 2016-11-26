using UnityEngine;
using System.Collections;

public class PowerButtonManager : MonoBehaviour {

	private LaserBeam theLaser;

	public int laserTime;
	private bool laserFlag = false;

	// Use this for initialization
	void Start () {
		theLaser = FindObjectOfType <LaserBeam> ();
	}

	public void startLaser(){
		if (laserFlag == false) {
			StartCoroutine (fireLaser (laserTime));
		}
	}

	IEnumerator fireLaser(int laserTime){
		laserFlag = true;
		theLaser.laserOn = true;
		// laser time 
		yield return new WaitForSeconds (laserTime);

		theLaser.laserOn = false;
		// wait to active again reload again 
		yield return new WaitForSeconds (laserTime);

		laserFlag = false;
	}

}
