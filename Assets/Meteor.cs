using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

    private Rigidbody2D Body;
    public float speed;
    private Vector2 _topright;
    private Vector2 _topleft;
	// Use this for initialization
	void Start () {

        _topright = Camera.main.ViewportToWorldPoint(new Vector2(1f,1f));
        _topleft = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));

        transform.position = _topleft;

        Body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Body.velocity = new Vector2(1f, -3f).normalized * speed;
	}
}
