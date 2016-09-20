using UnityEngine;
using System.Collections;

public class SimpleEnemy : MonoBehaviour {

    private EnemyBulletPool thepool; // get enemy form the enemypool
    private PlayerController theplayer;
    private Rigidbody2D bulletBody;
    private GameObject go;

    private bool isReady = false;

    public float enemySpeed;
    public float bulletSpeed;
    private float tmpX = 0f;
    private float tmpY = 0f;

    private Rigidbody2D enemyBody;

	// Use this for initialization
	void Start () {
        enemyBody = GetComponent<Rigidbody2D>();
        thepool = FindObjectOfType<EnemyBulletPool>();

        // fire bullet 
        InvokeRepeating("FireToPlayer",2f,5f);
        //FireToPlayer();
       // Invoke("FireToPlayer",1f);

	}
	
    void FireToPlayer(){
         go = thepool.getBullet(); // get enemy 

        if(go && isReady == false){
            theplayer = FindObjectOfType<PlayerController>();
            bulletBody = go.GetComponent <Rigidbody2D>();

            go.transform.position = transform.position; // enemy position or initial position 
            isReady = true;
            go.SetActive(true);
            //print("bullet found");
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        // move to bottom
        enemyBody.velocity = (Vector2.down * Time.deltaTime * enemySpeed);

        if(isReady){
            // fire bullet toward to theplayer
            bulletBody.velocity = (theplayer.transform.position - transform.position).normalized * bulletSpeed;
            isReady = false;
            print("bullet velocity : "+bulletBody.velocity);
        }

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // bottom left of screen
        if(transform.position.y < min.y){
            outOfScreen();
        }
	}


    void outOfScreen(){
        // enemy ship out of screen
        gameObject.SetActive(false);
       
        // bullet 
        //go.SetActive(false);
    }

   


} // end class 
