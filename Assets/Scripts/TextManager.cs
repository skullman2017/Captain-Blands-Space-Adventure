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
	void Start () {
		theText = GetComponent<Text>();

		//fullText.Replace("\\n", "\n");
	//	startDialogue();
	}
	
	IEnumerator typeWriteText(string text){

		yield return new WaitForSeconds(5f);

		for(int i=0;i <text.Length; i++){
			currentText = fullText.Substring(0,i);
			theText.text = currentText;
			yield return new WaitForSeconds(delay);
		}

	}

	public void startDialogue(){
		StartCoroutine(typeWriteText(fullText));
	}

}
