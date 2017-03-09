using System.Collections;
using UnityEngine;

public class Boss_1 : MonoBehaviour {

	
	private PlayerController thePlayer;
	private Vector2 posToStop;
	private Vector2 initialPos;
	MultipleEnemySpawner multipleEnemySpawner;
	// Use this for initialization
	void Start () {
		
		thePlayer = FindObjectOfType<PlayerController>();
		multipleEnemySpawner = GameObject.FindObjectOfType<MultipleEnemySpawner>();

		posToStop = new Vector2(transform.position.x, 3f);
		initialPos = transform.position;

		if(thePlayer){
			StartCoroutine(moveToPlayer(posToStop));
		}
	}
	
	
    
    IEnumerator moveToPlayer (Vector2 target) {

        while(Vector2.Distance(transform.position, target) >0.05f) {
            transform.position = Vector2.MoveTowards(transform.position,target,Time.deltaTime*1.5f);
            yield return null;
        }
      
        yield return new WaitForSeconds(1f);		 
	
		gameObject.BroadcastMessage("_startShooting");
		// shoot for sometime
		yield return new WaitForSeconds(15f);

		// then revert back to previous position
		StartCoroutine(backToPreviousPosition(initialPos));
		gameObject.BroadcastMessage("stopShooting");
    }

	IEnumerator backToPreviousPosition(Vector2 initialPos){
		//gameObject.BroadcastMessage("stopShooting");
		
		 while(Vector2.Distance(transform.position, initialPos) > 0.05f) {
            transform.position = Vector2.MoveTowards(transform.position, initialPos,Time.deltaTime*1.5f);
            yield return null;
        }
		yield return new WaitForSeconds(2f);
		
		// rocket enemy here 
		multipleEnemySpawner.Enemy_03();
		
		StartCoroutine(moveToPlayer(posToStop));
	}

	void Update(){
		// rotate with player 
		rotateWithPlayer();
	}


	void rotateWithPlayer(){
		Vector2 targetRotation = (thePlayer.transform.position-this.transform.position).normalized;
		float angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(transform.rotation.x, 0, angle-269f);
	}

} // end class 
