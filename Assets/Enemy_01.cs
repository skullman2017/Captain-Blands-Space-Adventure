using UnityEngine;
using System.Collections;

public class Enemy_01 : MonoBehaviour {

   
    public float moveSpeed;
    private EnemySpawner enemyspawner;

    private int currentPos = 0;
    private float reachDistance = 1f;

	// Use this for initialization
	void Start () {
        enemyspawner = FindObjectOfType<EnemySpawner>();
	}
	

	// Update is called once per frame
	void Update () {
        //Vector2 position = transform.position;

        float distance = Vector2.Distance(enemyspawner.paths[currentPos].position, transform.position);

        transform.position = Vector2.Lerp(transform.position, enemyspawner.paths[currentPos].position, moveSpeed * Time.deltaTime);

        if(distance <= reachDistance){
            currentPos++;
        }

        if(currentPos>=enemyspawner.paths.Length){
            currentPos = 0;
        }

	}

    void outofscreen(){
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if(transform.position.y < min.y){
            // 
            Debug.Log("out of camera set false");
        }
    }

}
