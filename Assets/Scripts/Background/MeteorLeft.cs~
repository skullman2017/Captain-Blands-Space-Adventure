using UnityEngine;
using System.Collections;

public class MeteorLeft : MonoBehaviour {

    private Rigidbody2D Body;
    public float speed;
    private bool isLeft = false;

    private Vector2 _bottomleft;
    private Vector2 _bottomright;

    private float rndX;
    private float rndY;
	// Use this for initialization
	void Start () {
       // Debug.Log("pos " + transform.position);

         _bottomleft = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        _bottomright = Camera.main.ViewportToWorldPoint(new Vector2(1f, 0f));

        rndX = Random.Range(-1f, _bottomright.x);
        rndY = -5f;

        //Debug.Log("rndX "+rndX);

        Body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if(transform.position.x <= _bottomright.x){
            //Debug.Log("topleft");
            Body.velocity = new Vector2(rndX, rndY).normalized * speed;
        }
       

       // Body.velocity = new Vector2(1f, -3f).normalized * speed;
	}


    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "KillBox"){
            gameObject.SetActive(false);
        }
    }

}


