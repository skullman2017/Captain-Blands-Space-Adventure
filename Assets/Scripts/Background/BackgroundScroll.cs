﻿using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

    public float moveSpeed;
    private float offset;
    private Material currentMat;

	// Use this for initialization
	void Start () {
        currentMat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        offset += moveSpeed * Time.deltaTime;
        offset = offset % 1.0f;
        currentMat.mainTextureOffset = new Vector2(0f, offset);
	}
}
