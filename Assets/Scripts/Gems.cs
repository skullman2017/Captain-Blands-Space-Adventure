using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gems : MonoBehaviour {

    public int scorePoint = 5;
    private string playerTag = "Player";

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * Time.deltaTime );
	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag==playerTag) {
            this.gameObject.SetActive(false);

            // add score to the scoreboard 
            ScoreManager.Instance.addScore(scorePoint);
        }
    }

}
