using UnityEngine;
using System.Collections;

public class SimpleEnemy : MonoBehaviour {

    private EnemyBulletPool thepool; // get enemy form the enemypool
    private PlayerController theplayer;
    private Vector2 thetarget;
    private Rigidbody2D bulletBody;

    private bool isReady = false;

    public float enemySpeed;
    public float bulletSpeed;

    private Rigidbody2D enemyBody;

	// Use this for initialization
	void Start () {
        enemyBody = GetComponent<Rigidbody2D>();
        thepool = FindObjectOfType<EnemyBulletPool>();

        // fire bullet 
        InvokeRepeating("FireToPlayer",3f,3f);
	}
	
    void FireToPlayer(){
        GameObject go = thepool.getBullet(); // get enemy 

        if(go){
            theplayer = FindObjectOfType<PlayerController>();
            bulletBody = go.GetComponent <Rigidbody2D>();
            thetarget = theplayer.transform.position;
            go.transform.position = transform.position; // enemy position 
            isReady = true;
            go.SetActive(true);
            print("bullet found");
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        // move to bottom
        enemyBody.velocity = Vector2.down * Time.deltaTime * enemySpeed;

        if(isReady){
            bulletBody.velocity = (theplayer.transform.position - transform.position)* bulletSpeed * Time.deltaTime;
            isReady = false;
        }

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // bottom left of screen
        if(transform.position.y < min.y){
            outOfScreen();
        }
	}


    void outOfScreen(){
        // out of screen
        gameObject.SetActive(false);
    }

    /*void OnBecameInvisible(){
        print("enemy out of camera");
        gameObject.SetActive(false);
    }*/


} // end class 
