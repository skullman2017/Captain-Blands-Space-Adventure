using UnityEngine;
using System.Collections;

public class PowerButtonManager : MonoBehaviour {

	private LaserBeam theLaser;
    public GameObject bombImage;
	public int laserTime;
	private bool laserFlag = false;
    private bool canBomb = true;
    public int bombCount = 2;


	// Use this for initialization
	void Start () {

        if (bombImage.activeInHierarchy) {
            bombImage.SetActive(false);
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

    IEnumerator explodeBomb() {

        bombImage.SetActive(true);
        canBomb = false;
        bombCount -= 1;

        while (bombImage.transform.localScale.x <= 25f) {
            yield return new WaitForSeconds(0.01f);
            bombImage.transform.localScale += new Vector3(1f*Time.deltaTime*50f, 1f*Time.deltaTime*50f, 1f*Time.deltaTime*50f);
        }

        bombImage.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        bombImage.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        canBomb = true;

    }

}
