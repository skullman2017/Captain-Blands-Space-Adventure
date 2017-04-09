using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeInNextScene : MonoBehaviour {

    public ScreenFader screenFader;
    public PlayerController thePlayer;
    public GameObject meteorLeft;
    public GameObject meteorRight;

   public void fade()
    {
        if (thePlayer != null)
        {
            thePlayer.CancelInvoke("FireBtn");
        }
        else { print("theplayer is null"); }

        meteorLeft.GetComponent<MeteorSpawnerLeft>().CancelInvoke("poolMeteor");
        meteorRight.GetComponent<MeteorSpawnerRight>().CancelInvoke("poolMeteor");

        StartCoroutine(fadeScreen(8f));

    }

   public IEnumerator fadeScreen(float t)
    {
        yield return new WaitForSeconds(t);

        screenFader.EndScene(6);

    }
    

}

