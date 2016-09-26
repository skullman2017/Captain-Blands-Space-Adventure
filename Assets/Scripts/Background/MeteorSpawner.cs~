using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour {

    private MeteorPooler thepool;
    private Vector2 _topleft;
    private Vector2 _topright;
	// Use this for initialization
	void Start () {
        thepool = FindObjectOfType<MeteorPooler>();
       
        _topright = Camera.main.ViewportToWorldPoint(new Vector2(1f,1f));
        _topleft = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));

        InvokeRepeating("poolMeteor",3f,0.5f);
    }
	
    void poolMeteor(){
        GameObject meteor = thepool.getMeteor();

        if(meteor!=null){
            int rndPos = Random.Range(10, 20);// for random topleft & topright
            //Debug.Log("rand "+ rndPos);
            setProperty( meteor , rndPos);

            //meteor.SetActive(true);
            //iTween.MoveTo(meteor, new Vector2(1f,0f), 0.5f);
        }

        //CancelInvoke();
    }

    void setProperty(GameObject go, int _rndpos){
        if(_rndpos <= 15){ 
            go.transform.position = _topleft;
        }
        else { 
            go.transform.position = _topright;
        }

        go.SetActive(true);
        //Debug.Log("pos "+go.transform.position);
    }   

    // Update is called once per frame
	void Update () {
	
	}

}
