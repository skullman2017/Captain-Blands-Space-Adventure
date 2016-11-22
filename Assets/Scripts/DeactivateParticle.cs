using UnityEngine;
using System.Collections;

public class DeactivateParticle : MonoBehaviour {

	private ParticleSystem theparticle;

	// Use this for initialization
	void Start () {
		theparticle = GetComponent <ParticleSystem> ();
	}

	// Update is called once per frame
	void Update () {
		if(!theparticle.IsAlive ()){
			//Debug.Log ("particle set to false");
			theparticle.gameObject.SetActive (false);
		}
	}
}
