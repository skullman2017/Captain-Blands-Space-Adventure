using UnityEngine;
using System.Collections;

public class SpaceRock : MonoBehaviour {

    private Transform path;
    private Rigidbody2D body;
    private RockSpawner rockSpawn;
    private Vector3 initialPos;

	// Use this for initialization
	void Start () {
        initialPos = transform.position;
      //  body = GetComponent<Rigidbody2D>();
       // path = FindObjectOfType<RockSpawner>().transform.GetChild(0);
        /* if(path){
            print(path.name);
        }*/
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //transform.position = Vector2.Lerp(transform.position, path.position, Time.deltaTime * 0.5f);
        //body.velocity = path.position * Time.deltaTime * Random.Range(5f,10f);
	}

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "KillBox"){
            //print("collide with killbox");
            transform.position = initialPos;
        }
        else if (other.tag == "Player"){
            //print("player");
        }
    }

}
