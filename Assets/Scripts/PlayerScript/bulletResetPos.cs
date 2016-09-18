using UnityEngine;
using System.Collections;

public class bulletResetPos : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "KillBox"){
            gameObject.SetActive(false);
        }
    }

}
