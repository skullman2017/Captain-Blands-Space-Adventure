using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;
    private PlayerController theplayer;
    private Vector2 target;
    private bool isReady = false;
    private GameObject go;
    private Rigidbody2D bulletBody;
	// Use this for initialization
	void Start () {
	    
        InvokeRepeating("waitAndFire",1f,1f);
	}
	
    void waitAndFire(){
        
        go = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        bulletBody = go.GetComponent<Rigidbody2D>();

        theplayer = FindObjectOfType<PlayerController>();
        target = theplayer.transform.position;
        isReady = true;
    }

	// Update is called once per frame
	void Update () {

        if(isReady){
          //  target = target - transform.position;
            bulletBody.velocity = theplayer.transform.position - transform.position;
            //iTween.MoveTo(go,target,1f);  
            isReady = false;
        }

	}
}
