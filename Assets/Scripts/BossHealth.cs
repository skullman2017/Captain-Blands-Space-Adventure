using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

	GameObject HealthCanvas;
	private Transform healthBar;
	public static Image health;
	private Vector2 screenPos = Vector2.zero;
	public Vector2 offset;
    //private TextManager textmanager;
    private LoadTargetScene loadScene;

	// Use this for initialization
	void Start () {
		HealthCanvas = GameObject.FindGameObjectWithTag("BossUI");
		

		if(HealthCanvas){
			healthBar = HealthCanvas.transform.GetChild(0);
			health = healthBar.transform.GetChild(0).GetComponent<Image>();

			// get the boss position in world to screen coordinate
			screenPos = Camera.main.WorldToScreenPoint(transform.position);
			//print(pos);
		}

        loadScene = Camera.main.GetComponent<LoadTargetScene>();
        //GameObject canvas = GameObject.FindGameObjectWithTag("UICanvas");

        //if(canvas) {
        //	textmanager = canvas.GetComponentInChildren<TextManager>();
        //}
        //else{ print("not found"); }

    }
	
	public static float damageHealthBar(double amount){
		health.fillAmount -= (float)amount;

        //print("health : " + health.fillAmount);
		// threshold used to stay boss when health is less than 20%
		return health.fillAmount;
	}

	public float getHealth(){
		return health.fillAmount;
	}

	void Update(){
		screenPos = Camera.main.WorldToScreenPoint(transform.position);
		healthBar.transform.position = (screenPos-offset);

	}

	 /// <summary>
	/// This function is called when the behaviour becomes disabled or inactive.
	/// </summary>
	void OnDisable(){
        //print("boss is disabled");
        //textmanager.startDialogue();

        //  FindObjectOfType<FadeInNextScene>().fade();
        loadScene.GameoverScene();

	}

}
