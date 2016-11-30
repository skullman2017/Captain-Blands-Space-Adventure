using UnityEngine;
using System.Collections;

public class MultipleEnemySpawner : MonoBehaviour {

	public Transform spawnPos1;
	public Transform spawnPos2;
	public Transform spawnPos3;
	public Transform spawnPos4;

	[Range(15,100)]
	public float _event_C_duration; // enemy 2

	public float max;
	public float min;

	// get call from eventmanager
	// event C
	public void spawnEnemy(){
		StartCoroutine (Enemy_02_pattern1 ());
		Enemy_03 ();
	}

	IEnumerator Enemy_02_pattern1(){

		float startTime = Time.time;
		float duration = _event_C_duration;
		while(Time.time - startTime < duration){
			yield return new WaitForSeconds (Random.Range (min, max));

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

	void Enemy_03(){

			for (int j = 1; j <= 2; j++) {

				GameObject go = MultipleEnemyPooler._Instance.getEnemy ((int)MultipleEnemyPooler.Enemies.Enemy_03);
				go.transform.position = spawnPos3.position;
				go.SetActive (true);

				for (int i = 1; i <= 2; i++) {
					GameObject go2 = MultipleEnemyPooler._Instance.getEnemy ((int)MultipleEnemyPooler.Enemies.Enemy_03_pattern2);
					go2.transform.position = spawnPos4.position;
					go2.SetActive (true);
				}
			}
	} // end 
		

}
