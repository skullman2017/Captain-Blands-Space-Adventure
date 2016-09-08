using UnityEngine;
using System.Collections;

public class Enemy_01 : MonoBehaviour {

   
    public float moveSpeed;
    private EnemySpawner enemyspawner;
    public float damage;
    private int currentPos = 0;
    private float reachDistance = 0.1f;
    private HealthBar healthbar;
	
    // Use this for initialization
	void Start () {
        enemyspawner = FindObjectOfType<EnemySpawner>();
        healthbar = transform.FindChild("HealthBar").GetComponent<HealthBar>();
	    
    }
	

	// Update is called once per frame
	void Update () {
        
        float distance = Vector2.Distance(enemyspawner.paths[currentPos].position, transform.position);
        //print(distance);

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

    // add some damage to enemy 
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Bullet"){
            
            float health = healthbar.giveDamage(damage);
            print(health);
            if(health <= 0){
                gameObject.SetActive(false);     
            }
        }

    } //end

}
