using UnityEngine;
using System.Collections;

public class Enemy_01 : MonoBehaviour {

   
    public float moveSpeed;
    private EnemySpawner enemyspawner;
    public float damage;
    private int currentPos = 0;
    private float reachDistance = 0.1f;
    private HealthBar healthbar;

    private ExplosionPooler explosionpool; // for explosion manager

    private float health;

    private bulletPooler BulletPool;
    public Transform bulletSpawnPos;
    private Vector2 bulletDirection;
    private bool isReady = false;
    private Rigidbody2D bulletBody;
    private GameObject bullet;
    public float bulletSpeed;

    // Use this for initialization
	void Start () {
        enemyspawner = FindObjectOfType<EnemySpawner>();
        healthbar = transform.FindChild("HealthBar").GetComponent<HealthBar>();

        // get references 
        explosionpool = FindObjectOfType<ExplosionPooler>();
        BulletPool = FindObjectOfType<bulletPooler>();

        // fire bullet repeatdely 
        InvokeRepeating("FireBullet", 2f,1f);
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
            


	} // end update

    void FireBullet(){
         bullet = BulletPool.getEnemyBullet();
     
        GameObject playerShip = GameObject.Find("Player");
        isReady = false;

        if(bullet != null && playerShip!=null){
            
            bulletDirection = playerShip.transform.position;
            bullet.transform.position = bulletSpawnPos.position; // initial position 
            bullet.SetActive(true);
            isReady = true;

        }
       
    }

    void FixedUpdate(){
        if (isReady){
            bullet.transform.Translate(bulletDirection*Time.deltaTime*bulletSpeed);
        }

    }
   
    // add some damage to enemy 
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Bullet"){
            col.gameObject.SetActive(false); // set bullet to false

            health = healthbar.giveDamage(damage);

            if(health <=0){
                healthbar.transform.localScale = new Vector2(1f, 1f);
                // controll enemy explosion and setFalse
                gameObject.SetActive(false);
                playAnimation(); // play explosion animation 
            }

        }

    } //end


    void playAnimation(){
        
        GameObject explode = explosionpool.getExplosion();
        explode.transform.position = transform.position;
        explode.SetActive(true);

    }

}
