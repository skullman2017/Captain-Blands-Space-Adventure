using UnityEngine;
using System.Collections;

public class StoryEnemy : MonoBehaviour {

	private PathEditor pathtofollow;
	private int currentWayPointID = 0;
	public GameObject shootFabs;
	public float speed;
	private float reachDistance = 0.1f;
	//public float rotationSpeed;
	public string pathName;
	private bool flag = false;
	private bool canShoot = true;
	public float secsToWait;
	private static int countEnemy = 0;

	// Use this for initialization
	void Start () {
		pathtofollow = GameObject.Find(pathName).GetComponent<PathEditor>();
		Invoke ("wait",2f);
	}

	void wait(){
		flag = true;
	}

	// Update is called once per frame
	void Update () {

		if (flag) {
			float distance = Vector2.Distance (pathtofollow.pathsObject [currentWayPointID].position, transform.position);
			transform.position = Vector2.MoveTowards (transform.position, pathtofollow.pathsObject [currentWayPointID].position, Time.fixedDeltaTime * speed);

			/*  Vector2 targetRotation = pathtofollow.pathsObject[currentWayPointID].position - transform.position;
        float angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;


        //var rotation = Quaternion.LookRotation(pathtofollow.pathsObject[currentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, angle);*/


			if (distance <= reachDistance) {
				currentWayPointID++;
			}

			if (currentWayPointID >= pathtofollow.pathsObject.Count) {
				currentWayPointID = pathtofollow.pathsObject.Count - 1;
			}

			if(canShoot){
				canShoot = false;
				StartCoroutine (Shoot ());
			}

		} // end 


	}

	IEnumerator Shoot(){
		yield return new WaitForSeconds (secsToWait);
		GameObject go = Instantiate (shootFabs, transform.position, Quaternion.identity) as GameObject;
		go.SetActive (true);
	}

	void OnBecameInvisible(){
		countEnemy++;
		if(countEnemy>=4){
			Camera.main.SendMessage ("fadeIn");
		}

	}

}
