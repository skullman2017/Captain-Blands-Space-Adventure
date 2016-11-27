using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {
	
	public Transform rayPos;
	public LayerMask enemyHitLayer;
	[Range(5,20)]
	public float maxLaserSize;
	public GameObject laserParticle;
	public int laserDamage;
	public bool laserOn = false; // switching variable 

	private bool spawned = false;
	private LineRenderer lineRenderer;
	private Transform laserHit;
	private PlayerController thePlayer;
	private Animator theAnimator;

	void Start(){
		lineRenderer = GetComponent <LineRenderer> ();
		lineRenderer.enabled = false;
		lineRenderer.sortingOrder = 5;

		theAnimator = GetComponent <Animator> ();
		thePlayer = GetComponentInParent <PlayerController> ();
	}
		
	void setFlag(){
		// get from animation - starting state
		spawned = true;
	}

	void LateUpdate(){
		
		// switching laser and player power

		if(laserOn){
			//	Debug.Log ("start");
			thePlayer.isFire = false;
			theAnimator.SetBool ("startLaser",true);
		}
		else if(laserOn == false){
			laserParticle.gameObject.SetActive (false);

			lineRenderer.enabled = false;
			theAnimator.SetBool ("startLaser",false);
			thePlayer.isFire = true;
			spawned = false;
		}

		if(spawned && thePlayer.isFire==false){

			float currentLaserSize = maxLaserSize;
			Vector2 laserDir = Vector2.up;

			lineRenderer.enabled = true;
			RaycastHit2D hit = Physics2D.Raycast (rayPos.position, laserDir, currentLaserSize,enemyHitLayer);

			if(hit.collider != null){
				lineRenderer.SetPosition (0,rayPos.position);
				lineRenderer.SetPosition (1, hit.point);

				laserParticle.transform.position = hit.point;
				laserParticle.gameObject.SetActive (true);

				damageEnemy (hit);

			}
			else{
				laserParticle.gameObject.SetActive (false);

				//Vector2 pos = new Vector2 (rayPos.position.x, transform.position.y+maxLaserSize);
					
				//lineRenderer.SetPosition (0,rayPos.position);
				//lineRenderer.SetPosition (1,pos);
			}
		}
		Vector2 pos = new Vector2 (rayPos.position.x, transform.position.y+maxLaserSize);
		lineRenderer.SetPosition (0,rayPos.position);
		lineRenderer.SetPosition (1,pos);
	} //end update

	void damageEnemy(RaycastHit2D _hit){
		if (_hit.collider.gameObject.layer == 10) {
			// enemy 
			//enemyHealth.giveDamage (laserDamage);
			_hit.transform.SendMessage ("giveDamage", laserDamage);
		}
		else if(_hit.collider.gameObject.layer == 12){
			// meteor
			//meteorHealth.giveMeteorDamage (laserDamage);
			_hit.transform.SendMessage ("giveLaserDamage", laserDamage);
		}
	}

}
