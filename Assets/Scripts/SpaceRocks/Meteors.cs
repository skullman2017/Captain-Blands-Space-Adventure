using UnityEngine;
using System.Collections;

public class Meteors : MonoBehaviour {

    public float smooth;
    private SpriteRenderer _sprite;
    private bool isHit = false;
	// Use this for initialization
	void Start () {
        _sprite = GetComponent<SpriteRenderer>();
	}
	
    void Update(){
        transform.Rotate(0f, 0f ,smooth );
     
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Bullet"){
            _sprite.color = new Color(255, 0, 0, 255); // when get hit 
            isHit = true;
            other.gameObject.SetActive(false);

            StartCoroutine(backToColor(0.5f));
        }


           
        //Debug.Log(other.name);
    }

    IEnumerator backToColor(float secs){
        yield return new WaitForSeconds(secs);
         // back to initial color 
        _sprite.color = new Color(255,255,255,255);

    }

    void OnTriggerStay2D(Collider2D col){
        //Debug.Log(col.tag);
    }

    public static void getMeteorDamage(int num){
        
    }

}
