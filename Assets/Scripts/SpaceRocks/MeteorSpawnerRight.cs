using UnityEngine;
using System.Collections;

public class MeteorSpawnerRight : MonoBehaviour {

    private MeteorPoolerRight thepool;
    private Vector2 _topleft;
    private Vector2 _topright;

    [Range(2,10)]
    public float _seconds;
    // Use this for initialization
    void Start () {
        thepool = FindObjectOfType<MeteorPoolerRight>();

        _topright = Camera.main.ViewportToWorldPoint(new Vector2(1f,1f));
        _topright += new Vector2(1.2f, 1f);


        InvokeRepeating("poolMeteor",5f, Random.Range(_seconds,_seconds*2));
    }

    void poolMeteor(){
        GameObject meteor = thepool.getMeteor();

        if(meteor!=null){
            meteor.transform.position = _topright;
            meteor.SetActive(true);
        }

        //CancelInvoke();
    }
}
