﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitByBulletAni : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

   public void destroy() {
        gameObject.SetActive(false);
        // spawn gems
    }
}
