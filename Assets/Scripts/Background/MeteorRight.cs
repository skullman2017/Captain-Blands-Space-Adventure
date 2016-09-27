using UnityEngine;
using System.Collections;

public class MeteorRight : MonoBehaviour {

    private Rigidbody2D Body;
    public float speed;
    private bool isLeft = false;

    private Vector2 _bottomleft;
    private Vector2 _bottomright;
    // Use this for initialization
    void Start () {
        // Debug.Log("pos " + transform.position);

        _bottomleft = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        //Debug.Log("bottomleft " + _bottomleft);
        _bottomright = Camera.main.ViewportToWorldPoint(new Vector2(1f, 0f));
        //Debug.Log("bottomright " + _bottomright);

        //if(transform.position.x )

        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        Body.velocity = new Vector2(-3f, -3f).normalized * speed;
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "KillBox"){
            gameObject.SetActive(false);
        }
    }

}


