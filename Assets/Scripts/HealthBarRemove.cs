using UnityEngine.UI;
using UnityEngine;

public class HealthBarRemove : MonoBehaviour {

	private Image healthFill;

	void Start () {
		healthFill = this.transform.GetChild(0).GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(healthFill.fillAmount<0.001f){
			this.gameObject.SetActive(false);
		}
	}
}
