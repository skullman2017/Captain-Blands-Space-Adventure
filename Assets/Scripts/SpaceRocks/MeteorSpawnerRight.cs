using UnityEngine;
using System.Collections;

public class MeteorSpawnerRight : MonoBehaviour {

    private MeteorPoolerRight thepool;
    private Vector2 _topleft;
    private Vector2 _topright;
    public float _seconds;
    // Use this for initialization
    void Start () {
        thepool = FindObjectOfType<MeteorPoolerRight>();

        _topright = Camera.main.ViewportToWorldPoint(new Vector2(1f,1f));
        _topright += new Vector2(1.2f, 1f);


        InvokeRepeating("poolMeteor",3f,_seconds);
    }

    void poolMeteor(){
        GameObject meteor = thepool.getMeteor();

        if(meteor!=null){
            int rndPos = Random.Range(10, 20);// for random topleft & topright
            //Debug.Log("rand "+ rndPos);
            meteor.transform.position = _topright;
            meteor.SetActive(true);

        }

        //CancelInvoke();
    }
}
