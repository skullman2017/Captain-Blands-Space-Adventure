using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsSpawner : MonoBehaviour {

    [HideInInspector]
    public static GemsPooler gemsPool;

    void Start() {
        gemsPool = FindObjectOfType<GemsPooler>();
    }


    /// <summary>
    /// give spawn position 
    /// </summary>
	public static void spawnGems(Vector3 pos) {
        GameObject go = gemsPool.getGems(0);
        go.transform.position = pos;
        go.SetActive(true);
    }

}
