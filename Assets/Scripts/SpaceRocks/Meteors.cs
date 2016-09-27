using UnityEngine;
using System.Collections;

public class Meteors : MonoBehaviour {

    public float smooth;
    public int health;

    [SerializeField]
    private int damage = 5; // player bullet hit damage

    private int initialHealth;
    private SpriteRenderer _sprite;

    // Use this for initialization
	void Start () {
        initialHealth = health;

        _sprite = GetComponent<SpriteRenderer>();
	}
	
    void Update(){
        transform.Rotate(0f, 0f ,smooth );

       // Debug.Log(health);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Bullet"){
            _sprite.color = new Color(255, 0, 0, 255); // when get hit 
            other.gameObject.SetActive(false);

            if (health > 0)
            {
                giveMeteorDamage(damage);
                StartCoroutine(backToColor(0.3f));
            }
            else{
                // health is zero kill meteor
                gameObject.SetActive(false);
                health = initialHealth; 
            }
                
        }
            
    } // end method 


    IEnumerator backToColor(float secs){
        yield return new WaitForSeconds(secs);
         // back to initial color 
        _sprite.color = new Color(255,255,255,255);

    }
        

    public void giveMeteorDamage(int num){
        health -= damage;
    }

}
