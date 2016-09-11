using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(0f, Time.deltaTime * moveSpeed);
        GetComponent<Renderer>().material.mainTextureOffset += offset;
        //myrenderer.material.mainTextureOffset = new Vector2(Time.deltaTime, Time.deltaTime * moveSpeed);
	}
}
