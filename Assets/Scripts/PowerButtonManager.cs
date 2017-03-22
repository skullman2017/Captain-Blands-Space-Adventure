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

    AudioSource laserCharge;
    AudioSource laserShoot;

	// Use this for initialization
	void Start () {

        if (playerBomb.activeInHierarchy) {
            playerBomb.SetActive(false);
        }

		theLaser = FindObjectOfType <LaserBeamTest> ();

        bombCntText.text = bombCount.ToString();
        laserCntText.text = laserCount.ToString();


        AudioSource[] audios = GetComponents<AudioSource>();

	}


    public  void laserUp(int cnt) {
        laserCount += cnt;
        laserCntText.text = laserCount.ToString();
    }

	public void startLaser(){

				if(laserCount>0){
					if (laserFlag == false) {
						 StartCoroutine (fireLaser ((int)theLaser.rayDuration));
					 }
                }
	}

	IEnumerator fireLaser(int laserTime){
		laserFlag = true;
        theLaser.FireLaser();

		int tmp = Convert.ToInt32(laserCntText.text);
        tmp += -1;
		laserCount = tmp;
        laserCntText.text = tmp.ToString();

        //theLaser.laserOn = true;
        // laser time

        yield return new WaitForSeconds(laserTime + 2f);

		laserFlag = false;
	}

    public void startBomb() {
        if (bombCount > 0 && bombFlag == true) {
             StartCoroutine(explodeBomb());
        }
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

        while (playerBomb.transform.localScale.x <= 23f) {
            playerBomb.transform.localScale += new Vector3(1f*Time.deltaTime*50f, 1f*Time.deltaTime*50f, 1f*Time.deltaTime*50f);
            yield return new WaitForSeconds(0.000001f);
        }

        playerBomb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        playerBomb.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        bombFlag = true;

    }


}
