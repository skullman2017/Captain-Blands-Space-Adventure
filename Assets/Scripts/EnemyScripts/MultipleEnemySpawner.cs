using UnityEngine;
using System.Collections;

public class MultipleEnemySpawner : MonoBehaviour {

	public Transform spawnPos1;
	[Range(20,60)]
	public float _event_C_duration;

	public float max;
	public float min;
	// Use this for initialization
	void Start () {
	
	}

	public void spawnEnemy(){
		StartCoroutine (Enemy_02_pattern1 ());
	}

	IEnumerator Enemy_02_pattern1(){

		float startTime = Time.time;
		float duration = _event_C_duration;

		//Debug.Log ("Event C");
		while(Time.time - startTime < duration){
			yield return new WaitForSeconds (Random.Range (max, min));

			for (int i = 1; i <= 3; i++) {
				GameObject enemy = MultipleEnemyPooler._Instance.getEnemy ((int)MultipleEnemyPooler.Enemies.Enemy_02);
				enemy.transform.position = new Vector2 (spawnPos1.position.x+i, spawnPos1.position.y);

				enemy.SetActive (true);
			}
		}
	}


}
