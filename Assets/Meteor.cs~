using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

    private Rigidbody2D Body;
    public float speed;

	// Use this for initialization
	void Start () {
       // Debug.Log("pos " + transform.position);

        Body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Body.velocity = new Vector2(1f, -3f).normalized * speed;
	}


    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "KillBox"){
            gameObject.SetActive(false);
        }
    }

}


