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
    public GameObject skipBtn;
    private StoryEnemy[] enemies;

	void Start(){
		scene1.SetActive (true);

		scene2.SetActive (false);
		PlayBtn.SetActive (false);
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

	void fadeIn(){
		//scene1.gameObject.SetActive (false);
		fadeDir = -1;

		StartCoroutine (nextScene ());
	}

	IEnumerator nextScene(){

        // kill the enemies and bullets dont need them
        removeAllEnemy();

		yield return new WaitForSeconds (2f);
		scene1.SetActive (false);

        Destroy(skipBtn);

		scene2.SetActive (true);

		fadeOut ();
	}

    void removeAllEnemy() {
        enemies = FindObjectsOfType<StoryEnemy>();

        if (enemies.Length > 0) {
            foreach (var go in enemies) {
                go.gameObject.SetActive(false);
            }
        }

    }

	void fadeOut(){
		
		fadeDir = 1;	

		StartCoroutine (gamePlay ());
	}

	IEnumerator gamePlay(){
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
