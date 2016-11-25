using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {
	
	public Transform rayPos;
	public LayerMask enemyHitLayer;
	[Range(5,20)]
	public float maxLaserSize;
	public GameObject laserParticle;

	private bool spawned = false;
	private LineRenderer lineRenderer;
	private Transform laserHit;


	void Start(){
		lineRenderer = GetComponent <LineRenderer> ();
		lineRenderer.enabled = false;
		lineRenderer.sortingLayerName = "Foreground";
	}

	void setFlag(){
		spawned = true;
	}

	void Update(){
		if(spawned){

			float currentLaserSize = maxLaserSize;
			Vector2 laserDir = Vector2.up;
			RaycastHit2D hit = Physics2D.Raycast (rayPos.position, laserDir, currentLaserSize,enemyHitLayer);

			if(!lineRenderer.enabled){
				lineRenderer.enabled = true;
			}

			if(hit.collider != null){
				float distance = Vector2.Distance (rayPos.position, hit.transform.position);

				//Debug.DrawLine (rayPos.position, hit.transform.position, Color.green);
				lineRenderer.SetPosition (0,rayPos.position);
				lineRenderer.SetPosition (1,hit.point);

				laserParticle.transform.position = hit.point;
				laserParticle.gameObject.SetActive (true);
			}
			else{
				laserParticle.gameObject.SetActive (false);

				Vector2 pos = new Vector2 (rayPos.position.x, transform.position.y+maxLaserSize);
				lineRenderer.SetPosition (0,rayPos.position);
				lineRenderer.SetPosition (1,pos);

			}
				
		}
	}

}
