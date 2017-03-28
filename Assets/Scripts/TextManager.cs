using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public float delay = 0.1f;
	public string fullText;
	private  string currentText;
	private Text theText;

	// Use this for initialization
	
	[HideInInspector]
	 float time = 3f;

	void Start () {
		theText = GetComponent<Text>();
	}
	
	IEnumerator typeWriteText(string text){

		yield return new WaitForSeconds(3f);

		for(int i=0;i <text.Length; i++){
			currentText = fullText.Substring(0,i);
			theText.text = currentText;
			yield return new WaitForSeconds(delay);
			time += delay;
			
		}
		time += 3f;
		//print("text duration : "+time);
		
	}

	public void startDialogue(){
		StartCoroutine(typeWriteText(fullText));
	}



}
