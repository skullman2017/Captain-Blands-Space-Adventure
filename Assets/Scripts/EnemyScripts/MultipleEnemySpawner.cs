using UnityEngine;
using System.Collections;

public class MultipleEnemySpawner : MonoBehaviour
{

    public Transform spawnPos1;
    public Transform spawnPos2;
    public Transform rocket1;
    public Transform rocket2;

    public Transform[] enemy_05_Pos;

    [Range(15, 100)]
    public float _event_C_duration; // enemy 2 pattern 1

    public float max;
    public float min;

    [Space(25)]
    public GameObject Boss1;
    public Transform bossSpawPos;

    private bool isBoss = false;
    private bool canCheckNow = false;

    void Start()
    {

    }

    // get call from eventmanager
    // event C
    public void spawnEnemy()
    {
        StartCoroutine(Enemy_02_pattern1());
		// rocket enemy
        Enemy_03();
    }

    IEnumerator Enemy_02_pattern1()
    {

        float startTime = Time.time;
        float duration = _event_C_duration;

        while (Time.time - startTime < duration)
        {
            yield return new WaitForSeconds(Random.Range(min, max));

            for (int i = 1; i <= 3; i++)
            {
                GameObject enemy = MultipleEnemyPooler._Instance.getEnemy((int)MultipleEnemyPooler.Enemies.Enemy_02_pattern1);
                enemy.transform.position = new Vector2(spawnPos1.position.x + i, spawnPos1.position.y);

                enemy.SetActive(true);

                for (int j = 0; j < 1; j++)
                {
                    GameObject enemy2 = MultipleEnemyPooler._Instance.getEnemy((int)MultipleEnemyPooler.Enemies.Enemy_02_pattern2);
                    enemy2.transform.position = new Vector2(spawnPos2.position.x - i, spawnPos1.position.y);
                    enemy2.SetActive(true);
                    break;
                }
            }
        }

        // initiate enemy - 5 event 
        StartCoroutine(Enemy_05_formation_1());

    } // end 

	///<summary>
	///Rocket Enemies 
	///</summary>
    public void Enemy_03()
    {

        GameObject go = MultipleEnemyPooler._Instance.getEnemy((int)MultipleEnemyPooler.Enemies.Enemy_03);
        go.transform.position = rocket1.position;
        go.SetActive(true);

        GameObject go2 = MultipleEnemyPooler._Instance.getEnemy((int)MultipleEnemyPooler.Enemies.Enemy_03);
        go2.transform.position = rocket2.position;
        go2.SetActive(true);


    } // end 


    public IEnumerator Enemy_05_formation_1()
    {

        print("now prepare for the Boss 1");

        yield return new WaitForSeconds(Random.Range(min, max));

        for (int i = 0; i < enemy_05_Pos.Length; i++)
        {
            GameObject go = MultipleEnemyPooler._Instance.getEnemy((int)MultipleEnemyPooler.Enemies.Enemy_05);
            go.transform.position = enemy_05_Pos[i].position;
            go.SetActive(true);
        }

        canCheckNow = true; // now update can check if Enemy_05 can exist or not

        yield return null;
    } // end 


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (canCheckNow)
        {
            if (isBoss == false)
            {
                bool ck = isAllDeath();
                if (ck)
                {
                    canCheckNow = false;
                    isBoss = true;
					StartCoroutine(instantiateBoss());
					print("boss instantiated");
                }
            }
        }

    } // end update

    bool isAllDeath()
    {
        Enemy_05[] enemies = GameObject.FindObjectsOfType<Enemy_05>();
        if (enemies.Length <= 0)
            return true;
        else
            return false;
    }


    // get call after enemy_05 event 
    public IEnumerator instantiateBoss()
    {
		yield return new WaitForSeconds(10f);
        GameObject bossObj = Instantiate(Boss1, bossSpawPos.position, Quaternion.identity) as GameObject;
    }

}
