using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public static void spawnMultipleGems(Vector2 pos) {
        for(int i = 0; i < 2 ; i++) {
            GameObject go = gemsPool.getGems(0);

            // random position 
            var x = Random.Range(pos.x - 0.35f, pos.x + 0.4f);
            var y = Random.Range(pos.y - 0.4f, pos.y + 0.3f);
            Vector2 randPos = new Vector2(x, y);

            go.transform.position = randPos;
            go.SetActive(true);
        }
    }

}
