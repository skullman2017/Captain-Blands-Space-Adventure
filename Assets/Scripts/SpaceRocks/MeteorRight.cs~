using UnityEngine;
using System.Collections;

public class MeteorRight : MonoBehaviour {

    private Rigidbody2D Body;
    public float speed;
    private bool isLeft = false;

    private Vector2 _bottomleft;
    private Vector2 _bottomright;

    private float rndX;
    private float rndY;

    // Use this for initialization
    void Start () {
        _bottomleft = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        _bottomright = Camera.main.ViewportToWorldPoint(new Vector2(1f, 0f));

        rndX = Random.Range(-1, -3);
        rndY = -4f;
            
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        Body.velocity = new Vector2(rndX, rndY).normalized * speed;
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "KillBox"){
            gameObject.SetActive(false);
        }
    }

}


