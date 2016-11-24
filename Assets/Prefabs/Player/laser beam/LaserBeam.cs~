using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {
	
	public Transform rayPos;
	public LayerMask enemyHitLayer;
	[Range(5,20)]
	public float maxLaserSize;
	public GameObject laserParticle;
	public SpriteRenderer laserLight;

	[Range(10,100)]
	public float sum;

	private bool spawned = false;
	private LineRenderer lineRenderer;
	private Transform laserHit;


	void Start(){
		lineRenderer = GetComponent <LineRenderer> ();
		lineRenderer.enabled = false;
		lineRenderer.sortingLayerName = "Foreground";
		laserLight.sortingLayerName = "Background";
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

				//laserLight.transform.position = rayPos.position;
				//laserLight.transform.localScale = new Vector2 (laserLight.transform.localScale.x, distance+sum);

				laserParticle.transform.position = hit.point;
				laserParticle.gameObject.SetActive (true);

				//Debug.Log ("hit");
			}
			else{
				laserParticle.gameObject.SetActive (false);

				Vector2 pos = new Vector2 (rayPos.position.x, transform.position.y+maxLaserSize);
				lineRenderer.SetPosition (0,rayPos.position);
				lineRenderer.SetPosition (1,pos);

				//laserLight.transform.position = rayPos.position;
				//laserLight.transform.localScale = new Vector2 (laserLight.transform.localScale.x, transform.position.y + maxLaserSize+sum);
			}
				
		}
	}

}
