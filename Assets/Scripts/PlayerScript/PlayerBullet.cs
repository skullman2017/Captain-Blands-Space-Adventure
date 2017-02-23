using UnityEngine;
using System.Collections;

// player bullet 
public class PlayerBullet : MonoBehaviour {


	public Sprite muzzleFlash; // muzzle flash sprite
	public int frameToFlash;

	private SpriteRenderer spriteRend; 
	private Sprite defaultSprite; // bullet sprite

    private Rigidbody2D bulletBody;
    [SerializeField]
    private float speed = 350f;
	private Vector2 topRightCorner;
	private bool flag = false;

    void Start(){
        bulletBody = GetComponent<Rigidbody2D>();
		spriteRend = GetComponent <SpriteRenderer> ();
		defaultSprite = spriteRend.sprite;

		topRightCorner = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		topRightCorner.y = topRightCorner.y + 0.5f; // for deactivate bullet when out of camera

		//Debug.Log ("muzzle flash");
		StartCoroutine (FlashMuzzleFlash ());
		flag = true;
    }


    void FixedUpdate(){
        bulletBody.velocity = Vector2.up * Time.deltaTime * speed;
    }
        

    void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "KillBox" || col.tag == "Enemy"){
            gameObject.SetActive(false);
        }
        
    }

	void Update(){
		if(transform.position.y > topRightCorner.y){
			//Debug.Log ("bullet out of camera");
			gameObject.SetActive (false);
		}
	}

	IEnumerator FlashMuzzleFlash(){
		spriteRend.sprite = muzzleFlash;

		for(int i=0;i<frameToFlash;i++){
			yield return 0;
		}

		spriteRend.sprite = defaultSprite;
	}

	void OnEnable(){
		if (flag == true) {
			StartCoroutine (FlashMuzzleFlash ());
			//Debug.Log ("enabled called");
		}
	}

}
