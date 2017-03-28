using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour {

    public Texture2D fadeTexture;

    [Range(0.1f,1f)]
    public float fadespeed;
    public int drawDepth = -1000;

    private float alpha = 0; 
    private float fadeDir = 0f;

	public GameObject scene1;
	public GameObject scene2;
	public GameObject PlayBtn;
	public NextScene theNextScene;

	void Start(){
		scene1.SetActive (true);

		scene2.SetActive (false);
		PlayBtn.SetActive (false);

       // fadeIn();
	  // Invoke("fadeIn",7f); // put the time value from textmanager
	}

	// runtime 
    void OnGUI() {

        alpha -= fadeDir * fadespeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        Color newColor = GUI.color; 
        newColor.a = alpha;

        GUI.color = newColor;

        GUI.depth = drawDepth;

        GUI.DrawTexture( new Rect(0,0, Screen.width, Screen.height), fadeTexture);

    }

	public void fadeIn(){
		fadeDir = -1;

		StartCoroutine (nextScene ());
	}

	IEnumerator nextScene(){

		yield return new WaitForSeconds (2f);
		scene1.SetActive (false);

		scene2.SetActive (true);

		fadeOut ();
	}



	void fadeOut(){
		
		fadeDir = 1;	
		// write text here 
			theNextScene.startDialogue();
		//StartCoroutine (gamePlay ());
	}

	public IEnumerator gamePlay(){
		yield return new WaitForSeconds (3f);

		StartCoroutine (ThefadeIn ());
	}

	IEnumerator ThefadeIn(){
		fadeDir = -1;
		yield return new WaitForSeconds (2f);

		fadeDir = 1;
		scene2.SetActive (false);

		PlayBtn.SetActive (true);
	}

}
