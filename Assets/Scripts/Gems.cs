﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour {


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * Time.deltaTime );
	}
}
