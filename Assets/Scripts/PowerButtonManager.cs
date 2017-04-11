using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PowerButtonManager : MonoBehaviour {

	private LaserBeamTest theLaser;
    public GameObject playerBomb;
	public int laserTime;
	private bool laserFlag = false;
    private bool bombFlag = true;

    public int laserCount;
    public int bombCount;

  	public Text bombCntText;
    public Text laserCntText;

    public PlayerController thePlayer;

    [Space(10)]
    [SerializeField]
    private Button LaserBtn;
    [SerializeField]
    private Button BombBtn;
	// Use this for initialization
    bool flag = false;

	void Start () {

        if (playerBomb.activeInHierarchy) {
            playerBomb.SetActive(false);
        }

		theLaser = FindObjectOfType <LaserBeamTest> ();

            bombCount = PlayerPrefs.GetInt("BOMB"); 
            laserCount = PlayerPrefs.GetInt("LASER");

           bombCntText.text = bombCount.ToString();
           laserCntText.text = laserCount.ToString();

    }


    public  void laserUp(int cnt) {
        laserCount += cnt;
        laserCntText.text = laserCount.ToString();
    }

	public void startLaser(){

				if(laserCount>0){
					if (laserFlag == false) {
                        // turn of player shoot 
                        thePlayer.CancelInvoke("FireBtn");

						 StartCoroutine (fireLaser ((int)theLaser.rayDuration));
					 }
                }
	}

	IEnumerator fireLaser(int laserTime){
		laserFlag = true;
        theLaser.FireLaser();

        laserCount -= 1;
        laserCntText.text = laserCount.ToString();
        PlayerPrefs.SetInt("LASER", laserCount);

        //theLaser.laserOn = true;
        // laser time

        yield return new WaitForSeconds(laserTime + 2f);

		laserFlag = false;

        // turn on player shoot again 
       thePlayer.InvokeRepeating("FireBtn",1.5f, thePlayer.fireRate);
	}

    public void startBomb() {
        if (bombCount > 0 && bombFlag == true) {
             StartCoroutine(explodeBomb());
        }
    }

     /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        if(LaserBtn != null)
            LaserBtn.interactable = false;
        else if(BombBtn != null)
             BombBtn.interactable = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            startBomb();
        }
    }

    IEnumerator explodeBomb() {

        playerBomb.SetActive(true);
        bombFlag = false;
        bombCount -= 1;
        bombCntText.text = bombCount.ToString();
        PlayerPrefs.SetInt("BOMB", bombCount);

        // play death wave sound 
        SoundManager.Instance.playDeathWaveSFX();

        while (playerBomb.transform.localScale.x <= 23f) {
            playerBomb.transform.localScale += new Vector3(1f*Time.deltaTime*50f, 1f*Time.deltaTime*50f, 1f*Time.deltaTime*50f);
            yield return new WaitForSeconds(0.001f);
        }

        playerBomb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        playerBomb.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        bombFlag = true;

    }


}
