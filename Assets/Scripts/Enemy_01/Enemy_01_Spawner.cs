using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Enemy_01_Spawner : MonoBehaviour {

    private Enemy_01_Pooler thepooler;

    void Start(){
        thepooler = FindObjectOfType<Enemy_01_Pooler>();

        //StartCoroutine(testEnemy());
    }

    IEnumerator testEnemy(){
        yield return new WaitForSeconds(2f);

        GameObject go = thepooler.getEnemy_01("MoveLeftToRight");
        go.SetActive(true);
    }

}
