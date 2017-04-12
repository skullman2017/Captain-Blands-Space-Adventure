using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


    public static ScoreManager Instance ;

    public Text scoreText;
    public  int SCORE = 0;

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

    public void saveCurrentScore(int score){
        PlayerPrefs.SetInt("PLAYER_CURRENT_SCORE",score);
        print("current score "+score);
    }

    public void saveTotalScore(int score){

       int totalScore = 0;

       if(PlayerPrefs.GetInt("PLAYER_TOTAL_SCORE")==0){
           PlayerPrefs.SetInt("PLAYER_TOTAL_SCORE",score);
       }
       else{
        totalScore = PlayerPrefs.GetInt("PLAYER_TOTAL_SCORE");
        totalScore += score;
        PlayerPrefs.SetInt("PLAYER_TOTAL_SCORE",totalScore);
       }

    }

}
