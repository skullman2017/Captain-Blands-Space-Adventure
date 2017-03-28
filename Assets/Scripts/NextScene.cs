using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NextScene : MonoBehaviour {


	public float delay = 0.1f;
	public string fullText;
	private  string currentText;
	private Text theText;
	public FadeScreen fadeScreen;
	// Use this for initialization
	
	[HideInInspector]
	 float time = 0;

	void Start () {
		theText = GetComponent<Text>();
	}
	
	public IEnumerator typeWriteText(string text){

		yield return new WaitForSeconds(1f);

		for(int i=0;i <text.Length; i++){
			currentText = fullText.Substring(0,i);
			theText.text = currentText;
			yield return new WaitForSeconds(delay);
			time += delay;
			
		}
		time += 2f;

		//print("text duration : "+time);
		//fadeScreen.fadeIn();
		fadeScreen.StartCoroutine("gamePlay");
		
		StartCoroutine(fadeText(theText));
	}

		IEnumerator fadeText(Text txt){

		yield return new WaitForSeconds(1f);
		
		Text myText= txt.GetComponent<Text>();

		while(myText.color.a>0){

		Color c = myText.color;
		c.a -= 1f*Time.deltaTime;
		myText.color = c;	
		
		yield return null;

		}

		theText.text = string.Empty;
		myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, 255);
	}

	 public void startDialogue(){
		StartCoroutine(typeWriteText(fullText));
	}
	
}
