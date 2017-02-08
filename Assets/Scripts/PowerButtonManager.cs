using UnityEngine;
using System.Collections;

public class PowerButtonManager : MonoBehaviour {

	private LaserBeam theLaser;
    public GameObject playerBomb;
	public int laserTime;
	private bool laserFlag = false;
    private bool canBomb = true;
    public int bombCount = 2;


	// Use this for initialization
	void Start () {

        if (playerBomb.activeInHierarchy) {
            playerBomb.SetActive(false);
        }
		theLaser = FindObjectOfType <LaserBeam> ();
	}

	public void startLaser(){

        //StartCoroutine(explodeBomb());

		if (laserFlag == false) {
		    StartCoroutine (fireLaser (laserTime));
		}
	}

	IEnumerator fireLaser(int laserTime){
		laserFlag = true;
		theLaser.laserOn = true;
		// laser time 
		yield return new WaitForSeconds (laserTime);

		theLaser.laserOn = false;
		// wait to active again reload again 
		yield return new WaitForSeconds (laserTime);

		laserFlag = false;
	}

    public void startBomb() {
        if (bombCount > 0 && canBomb == true) {
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
        canBomb = false;
        bombCount -= 1;

        while (playerBomb.transform.localScale.x <= 23f) {
            playerBomb.transform.localScale += new Vector3(1f*Time.deltaTime*50f, 1f*Time.deltaTime*50f, 1f*Time.deltaTime*50f);
            yield return new WaitForSeconds(0.000001f);
        }

        playerBomb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        playerBomb.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        canBomb = true;

    }


}
