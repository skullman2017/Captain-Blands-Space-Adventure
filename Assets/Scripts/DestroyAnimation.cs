﻿using UnityEngine;
using System.Collections;

public class DestroyAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void destroy(){
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
