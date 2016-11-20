using UnityEngine;
using System.Collections;

public class MultipleEnemySpawner : MonoBehaviour {

	public Transform spawnPos1;
	public Transform spawnPos2;
	[Range(20,100)]
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

		Debug.Log ("Event C 1");
		while(Time.time - startTime < duration){
			yield return new WaitForSeconds (Random.Range (max, min));

			for (int i = 1; i <= 3; i++) {
				GameObject enemy = MultipleEnemyPooler._Instance.getEnemy ((int)MultipleEnemyPooler.Enemies.Enemy_02_pattern1);
				enemy.transform.position = new Vector2 (spawnPos1.position.x+i, spawnPos1.position.y);

				enemy.SetActive (true);

				for(int j=0;j<1;j++){
					GameObject enemy2 = MultipleEnemyPooler._Instance.getEnemy ((int)MultipleEnemyPooler.Enemies.Enemy_02_pattern2);
					enemy2.transform.position = new Vector2 (spawnPos2.position.x-i, spawnPos1.position.y);
					enemy2.SetActive (true);
					break;
				}
			}
		}

	} // end 

/*	IEnumerator Enemy_02_pattern2(){

		float startTime = Time.time;
		float duration = _event_C_duration;

		Debug.Log ("Event C 2");
		while(Time.time - startTime < duration){
			yield return new WaitForSeconds (Random.Range (max, min));

			for (int i = 1; i <= 3; i++) {
				GameObject enemy = MultipleEnemyPooler._Instance.getEnemy ((int)MultipleEnemyPooler.Enemies.Enemy_02);
				enemy.transform.position = new Vector2 (spawnPos1.position.x+i, spawnPos1.position.y);

				enemy.SetActive (true);
			}
		}
	}*/


}
