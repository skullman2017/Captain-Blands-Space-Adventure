using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour {

    private MeteorPooler thepool;
    private Vector2 _topleft;
    private Vector2 _topright;
	// Use this for initialization
	void Start () {
        thepool = FindObjectOfType<MeteorPooler>();

        InvokeRepeating("poolMeteor",3f,0.5f);
    }
	
    void poolMeteor(){
        GameObject meteor = thepool.getMeteor();

        if(meteor!=null){
           
            meteor.SetActive(true);
            //iTween.MoveTo(meteor, new Vector2(1f,0f), 0.5f);
        }

        CancelInvoke();
    }

    void setProperty(GameObject go, int _rndpos){
        //if(_rndpos == 1){ go.transform.position = _topleft; }
       // else { go.transform.position = _topright; }
    }   

    // Update is called once per frame
	void Update () {
	
	}

}
