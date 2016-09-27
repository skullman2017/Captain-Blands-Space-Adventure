using UnityEngine;
using System.Collections;

public class Meteors : MonoBehaviour {

    public float smooth;

	// Use this for initialization
	void Start () {
	
	}
	
    void Update(){
        transform.Rotate(0f, 0f ,smooth );
        //iTween.RotateUpdate(this.gameObject,new Vector3(0f,0f,10f),Time.deltaTime * smooth);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Bullet"){
            other.gameObject.SetActive(false);
        }
        //Debug.Log(other.name);
    }


}
