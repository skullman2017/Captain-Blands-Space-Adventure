using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {
	
	/*private bool spawned = false;
	private GameObject _start;
	private GameObject _mid;
	private GameObject _end;

	public Transform midPos;
	public Transform rayPos;
	public GameObject laserStart;
	public GameObject laserMid;
	public GameObject laserEnd;
*/
	public Transform rayPos;
	public LayerMask enemyHitLayer;
	[Range(5,20)]
	public float maxLaserSize;

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
				Debug.DrawLine (rayPos.position, hit.transform.position, Color.green);
				lineRenderer.SetPosition (0,rayPos.position);
				lineRenderer.SetPosition (1,hit.point);
				Debug.Log ("hit");
			}
			else{
				Vector2 pos = new Vector2 (rayPos.position.x, transform.position.y+maxLaserSize);
				lineRenderer.SetPosition (0,rayPos.position);
				lineRenderer.SetPosition (1,pos);
			}



		}
	}

/*
	// Update is called once per frame
	void Update () {
		if(spawned){
			// do stuff
			if(!laserStart.activeInHierarchy){
				laserStart.SetActive (true);
			}

			if(_mid == null){
				_mid = Instantiate (laserMid, midPos.position, Quaternion.identity) as GameObject;
				_mid.transform.parent = this.transform;
			}

			float currentLaserSize = maxLaserSize;
			Vector2 laserDir = Vector2.up;
			RaycastHit2D hit = Physics2D.Raycast (rayPos.position, laserDir, currentLaserSize,enemyHitLayer);

			// laser hit something
			if(hit.collider != null){
				currentLaserSize = Vector2.Distance (hit.point, transform.position);
				Debug.DrawLine (transform.position, hit.transform.position,Color.green);

				Debug.Log ("hit something");
			}
			else{
				Debug.Log ("did not hit");
			}

			// place sprites
			float midSpriteHeight = _mid.GetComponent <Renderer> ().bounds.size.y;
			_mid.transform.localScale = new Vector2 (1, currentLaserSize);
			_mid.transform.localPosition = new Vector2 (midPos.position.x, (midSpriteHeight));

		}


	} // end
	*/



}
