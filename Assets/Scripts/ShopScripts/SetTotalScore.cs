using UnityEngine;
using UnityEngine.UI;
public class SetTotalScore : MonoBehaviour {

	private Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text>();
		int totalScore = PlayerPrefs.GetInt("PLAYER_TOTAL_SCORE");

		scoreText.text = totalScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
