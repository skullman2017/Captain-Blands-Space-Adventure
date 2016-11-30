using UnityEngine;
using System.Collections;

public class ChildChecker : MonoBehaviour {

	private bool flag = false;
	private int cnt = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(flag == true){
			Debug.Log ("child false");
			flag = false;
			this.gameObject.SetActive (false);
		}

		foreach(Transform bullet in transform){
			Debug.Log ("child");
			if(bullet.gameObject.activeInHierarchy == false){
				cnt++;
			}
			if(cnt>=3){
				flag = true;
			}
		}

	} // end 


}
