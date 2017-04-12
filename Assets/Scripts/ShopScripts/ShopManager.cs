using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ShopManager : MonoBehaviour {

	public Text warningText;
	public Text totalText;
	public Text bombBuyText;
	public Text laserBuyText;
	private int totalScore = 0;
	private int currentScore = 0;

	public int bombPrice = 300;
	public int laserPrice = 500;
	public int bombCnt = 0;
	public int laserCnt = 0;
	bool Flag = true;


	// Use this for initialization
	void Start () {	
		warningText.text = string.Empty;

         //PlayerPrefs.SetInt("BOMB", 1);
        // PlayerPrefs.SetInt("PLAYER_TOTAL_SCORE", 2000);

        AddManager.Instance.showVideoAdd();

    }
	
	public void buyBomb(){
		totalScore = PlayerPrefs.GetInt("PLAYER_TOTAL_SCORE");

		if(totalScore>=bombPrice){

            bombCnt += 1; // bought one bomb 
			bombBuyText.text = bombCnt.ToString();

			totalScore -= bombPrice;
			totalText.text = totalScore.ToString();
			PlayerPrefs.SetInt("PLAYER_TOTAL_SCORE", totalScore);

			PlayerPrefs.SetInt("BOMB",bombCnt); // store 
		}
		else{
			
			warningText.text = "YOU DONT HAVE ENOUGH MONEY !";
			//StopCoroutine("fadeText");
			if(Flag == true){
				StartCoroutine(fadeText(warningText));
				Flag = false;
			}
		}

	}


	public void buyLaser(){
		totalScore = PlayerPrefs.GetInt("PLAYER_TOTAL_SCORE");

		if(totalScore>=laserPrice){
            laserCnt +=1;
			laserBuyText.text = laserCnt.ToString();

			totalScore -= laserPrice;
			totalText.text = totalScore.ToString();
			PlayerPrefs.SetInt("PLAYER_TOTAL_SCORE", totalScore);

			PlayerPrefs.SetInt("LASER",laserCnt);
		}
		else{
			
			warningText.text = "YOU DONT HAVE ENOUGH MONEY !";
			//StopCoroutine("fadeText");
			if(Flag == true){
				StartCoroutine(fadeText(warningText));
				Flag = false;
			}
		}
	}

	IEnumerator fadeText(Text txt){
		Flag = false;
		yield return new WaitForSeconds(1f);
		
		Text myText= txt.GetComponent<Text>();

		while(myText.color.a>0){

		Color c = myText.color;
		c.a -= 1f*Time.deltaTime;
		myText.color = c;	
		
		yield return null;

		}

		warningText.text = string.Empty;
		myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, 255);
		Flag = true;
	}
	

}
