using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    private bulletPooler objPooler;

    public float fireRate;
    public Transform bulletSpawnPos1; // instantiate position 
    public Transform bulletSpawnPos2;

    private Vector3 spawPos1;
    private Vector3 spawPos2;

    private float accleStartY;

    // player audio 
    private AudioSource playerAudioSource;
    private PlayerHealth playerHealth;
    public float playerDamage;

    private Rigidbody2D playerBody;

	// Use this for initialization
	void Start () {
        playerAudioSource = GetComponent<AudioSource>();
        playerBody = GetComponent<Rigidbody2D>();

        objPooler = FindObjectOfType<bulletPooler>();

        accleStartY = Input.acceleration.y; // mobile 
        // get PlayerHealth script
        playerHealth = FindObjectOfType<PlayerHealth>();

        // player set initial position 
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 _dir = new Vector2(h, v);
        movePlayer(_dir);

        // firing autometically 
        InvokeRepeating("FireBtn",3f, fireRate);
		//InvokeRepeating ("muzzleFlash",3f,fireRate);

	}
	

	// Update is called once per frame
	void Update () {
        // for joystikc controll
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
	    
        // for accleometer 
        //float h = Input.acceleration.x;
       // float v = Input.acceleration.y - accleStartY;

        // get the joystick input 
        Vector2 direction = new Vector2(h,v);

        if(direction.sqrMagnitude > 1){
            direction.Normalize();  
        }
            
        // moveplayer
        movePlayer(direction);
        // tap to fire 
        //FireBtn();

       
    } // end 

    public void FireBtn(){
        // fire bullets
        //if(Input.GetMouseButtonDown(0)){
            //print("fire btn down");
            spawPos1 = bulletSpawnPos1.position; // update the postion 
            spawPos2 = bulletSpawnPos2.position;

            playerAudioSource.Play(); // play fire sfx
			FireBullet();
      //  }
    }

    public void movePlayer(Vector2 dir){
        //transform.Translate(h*Time.deltaTime * moveSpeed ,v*Time.deltaTime * moveSpeed,transform.position.z);
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // return the bottom-left position 
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // return the top-right position

        max.x = max.x - 0.5f; // subtract player sprite half 
        min.x = min.x + 0.5f;

        max.y = max.y - 0.5f;
        min.y = min.y + 0.5f;

        // get the player current position 
        Vector2 playerPos = transform.position; 
        playerPos += dir * moveSpeed * Time.deltaTime; // calculate player new position
        // bound the world
        playerPos.x = Mathf.Clamp(playerPos.x , min.x, max.x);
        playerPos.y = Mathf.Clamp(playerPos.y , min.y, max.y);

        // update player position 
        transform.position = Vector2.Lerp(transform.position,playerPos, Time.deltaTime * moveSpeed);
    }


    void FireBullet(){
        int b1 = 0;
        int b2 = 0;


        for(int i=0;i<objPooler.bulletPool.Count;i++){
            if(objPooler.bulletPool[i].activeInHierarchy == false){
                b1 = i;

                for(int j=i+1;j<objPooler.bulletPool.Count; j++){
                    if(objPooler.bulletPool[j].activeInHierarchy == false){
                        b2 = j;
                        break;
                    }    
                } // 
                break;
            }
        }

        // set player bullet gravity to -4 if dont want velocity at run time
        objPooler.bulletPool[b1].transform.position = spawPos1;
        objPooler.bulletPool[b1].SetActive(true);

        objPooler.bulletPool[b2].transform.position = spawPos2;
        objPooler.bulletPool[b2].SetActive(true);


    } // end 


	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Enemy"){
			iTween.ShakePosition (gameObject, new Vector2 (0.5f, 0.5f), Time.deltaTime*4f);
		}
	}

}
