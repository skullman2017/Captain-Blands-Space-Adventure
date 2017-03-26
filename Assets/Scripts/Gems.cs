using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gems : MonoBehaviour {

    public int scorePoint = 5;
    private string playerTag = "Player";
    private SoundManager soundManager;
    // Use this for initialization
    void Start () {
        // soundManager =  FindObjectOfType<SoundManager>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * Time.deltaTime );
	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag==playerTag) {
            this.gameObject.SetActive(false);

            SoundManager.playGemSound();
            // add score to the scoreboard 
            ScoreManager.Instance.addScore(scorePoint);
        }
    }

}
