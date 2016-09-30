using UnityEngine;
using System.Collections;

public class MeteorSpawnerLeft : MonoBehaviour {

    private MeteorPoolerLeft thepool;
    private Vector2 _topleft;
    private Vector2 _topright;

    [Range(2,10)]
    public float _seconds;
	// Use this for initialization
	void Start () {
        thepool = FindObjectOfType<MeteorPoolerLeft>();
       
        //_topright = Camera.main.ViewportToWorldPoint(new Vector2(1f,1f));
        //_topright += new Vector2(1.2f, 1f);

        _topleft = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
        _topleft += new Vector2(-1.2f,1f);
        //Debug.Log(_topleft);

        InvokeRepeating("poolMeteor",3f,Random.Range(_seconds,_seconds*2));
    }
	
    void poolMeteor(){
        GameObject meteor = thepool.getMeteor();

        if(meteor!=null){
            setProperty( meteor);
        }

        //CancelInvoke();
    }

    void setProperty(GameObject go){
        go.transform.position = _topleft;

        go.SetActive(true);
        //Debug.Log("pos "+go.transform.position);
    }   

    // Update is called once per frame
	void Update () {
	
	}

}
