using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 1f;
    private bulletPooler objPooler;
    private BulletSpawnPos bulletSpawnPos;
    private Vector3 spawPos;
 
    private AudioSource playerAudioSource;

	// Use this for initialization
	void Start () {
        playerAudioSource = GetComponent<AudioSource>();

        bulletSpawnPos = FindObjectOfType<BulletSpawnPos>();
        objPooler = FindObjectOfType<bulletPooler>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
	    // get the joystick input 
        Vector2 direction = new Vector2(h,v).normalized;
        // moveplayer
        movePlayer(direction);

        // fire bullets
        if(CrossPlatformInputManager.GetButtonDown("Fire1")){
            spawPos = bulletSpawnPos.transform.position; // update the postion 
            playerAudioSource.Play(); // play fire sfx
            FireBullet();
        }
           
    } // end 

    void movePlayer(Vector2 dir){
        //transform.Translate(h*Time.deltaTime * moveSpeed ,v*Time.deltaTime * moveSpeed,transform.position.z);
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // return the bottom-left position 
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // return the top-right position

        // get the player current position 
        Vector2 playerPos = transform.position; 
        playerPos += dir * moveSpeed * Time.deltaTime; // calculate player new position
        // bound the world
        playerPos.x = Mathf.Clamp(playerPos.x , min.x, max.x);
        playerPos.y = Mathf.Clamp(playerPos.y , min.y, max.y);

        // update player position 
        transform.position = playerPos;
    }

    void FireBullet(){
        for(int i =0;i<objPooler.bulletPool.Count;i++){
            if(objPooler.bulletPool[i].activeInHierarchy == false){
                objPooler.bulletPool[i].transform.position = spawPos;
                objPooler.bulletPool[i].SetActive(true);
                break;
            }
        }

    } // end 
        

}
