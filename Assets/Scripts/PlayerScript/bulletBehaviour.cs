using UnityEngine;
using System.Collections;

public class bulletBehaviour : MonoBehaviour {

    private Rigidbody2D bulletBody;

	// Use this for initialization
	void Start () {
        bulletBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //bulletBody.velocity = new Vector2(transform.position.x, 5f);
	}
}
