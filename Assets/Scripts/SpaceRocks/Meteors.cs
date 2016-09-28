using UnityEngine;
using System.Collections;

public class Meteors : MonoBehaviour {

    public float smooth;
    public int health;

    public int damage; // player bullet hit damage

    private int initialHealth;
    private SpriteRenderer _sprite;

    // Use this for initialization
	void Start () {
        initialHealth = health;

        _sprite = GetComponent<SpriteRenderer>();
        _sprite.color = new Color(255, 255, 255, 255);
	}
	
    void Update(){
        transform.Rotate(0f, 0f ,smooth );

       // Debug.Log(health);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Bullet" && gameObject.activeInHierarchy){

            other.gameObject.SetActive(false); // bullet kill

            StartCoroutine(changeColor(0.2f));

            if (health > 0)
            {
                //Debug.Log(gameObject.name + "health : "+health);
                giveMeteorDamage(damage);
                //StartCoroutine(backToColor(0.2f));
            }
            else{
                // health is zero kill meteor
                _sprite.color = new Color(255,255,255,255);
                gameObject.SetActive(false);
                health = initialHealth; 
            }
                
        }
            
    } // end method 

    // back to initial color
    IEnumerator changeColor(float secs){
        _sprite.color = new Color(255, 0, 0, 255); // when get hit

        yield return new WaitForSeconds(secs);
         // back to initial color 
        _sprite.color = new Color(255,255,255,255);

    }
        

    public void giveMeteorDamage(int num){
        health -= damage;
    }

}
