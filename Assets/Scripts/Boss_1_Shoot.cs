using System.Collections;
using UnityEngine;

public class Boss_1_Shoot : MonoBehaviour {


	private float pushTime = 2;

	[Range(0.1f,1f)]
	public float repeatRate;
	public GameObject bullet;
	// Use this for initialization
	void Start () {
			
	}
	
	public void _startShooting(){
		StartCoroutine(startShooting(pushTime));
	}
	
	IEnumerator startShooting(float t){
		print("startShooting");
		//Instantiate(bullet, transform.position, transform.rotation);
		

		float startTime = Time.time;
		float duration = 10f; // shooting duration

		while(Time.time - startTime < duration){
			yield return new WaitForSeconds (0.30f);
			fire();
			//Instantiate(bullet, transform.position, transform.rotation);
		}

		//print("end phase");
		yield return new WaitForSeconds(pushTime);
		
		//print("start phase");
		StartCoroutine(startShooting(pushTime));
	
	}

	void OnDisable(){
		stopShooting();
	}

	public void stopShooting(){
		 StopAllCoroutines();
	}

	void fire(){
		GameObject go = EnemyBulletPooler._Instance.getBullet((int)EnemyBulletPooler.Enemies.Enemy_01);
		go.transform.position = this.transform.position;
		go.transform.rotation = this.transform.rotation;
		go.SetActive(true);
	}

}
