using UnityEngine;
using System.Collections;

public class SimpleEnemySpawner : MonoBehaviour {

    private EnemyPoolManager theEnemyPool;
    public float secToWait;
    private GameObject enemy;

    // enemy spawn position 
    private Vector2 _topleft;
    private Vector2 _topright;
    private Vector2 _center;

	// Use this for initialization
	void Start () {
        theEnemyPool = FindObjectOfType<EnemyPoolManager>();

        setSpawnPos();

        StartCoroutine(poolEnemy(secToWait));
	}
	
    void setSpawnPos(){
        _topleft = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
        _topleft.x = _topleft.x + 0.5f;
        _topright = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        _topright.x = _topright.x - 0.5f;
        _center = Camera.main.ViewportToWorldPoint(new Vector2(0.5f,1));
    }

    IEnumerator poolEnemy(float _sec){
        yield return new WaitForSeconds(_sec);

        enemy = theEnemyPool.getEnemy("SimpleEnemy");
        if(enemy){

            int rnd = Random.Range(1, 3);
            enemy.SetActive(true);

            if (rnd == 1)
            {
                enemy.transform.position = _topleft;
            }
            else if (rnd == 2)
            {
                enemy.transform.position = _center;
            }
            else
            {
                enemy.transform.position = _topright;
            }
                
        }

        // start again
       // StartCoroutine(poolEnemy(Random.Range(secToWait,secToWait+2f)));
    } // end method 

	


}
