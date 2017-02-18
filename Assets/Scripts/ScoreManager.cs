using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


    public static ScoreManager Instance ;

    public Text scoreText;
    private  int SCORE = 0;

    private static  ScoreManager instance
    {
        get {
            if(Instance == null) {
                Instance = FindObjectOfType<ScoreManager>();
            }

            if(Instance == null) {
                GameObject go = new GameObject("ScoreManager");
                go.AddComponent<ScoreManager>();
            }

            return instance;
        }
    }
    
    void Awake() {
        Instance = this;
    }


    public void addScore(int _score) {
        SCORE += _score;
        scoreText.text = SCORE.ToString();

    }

    /// <summary>
    /// little animation for score addition
    /// </summary>
    private void scoreTween() {
            // pop up score
    }

}
