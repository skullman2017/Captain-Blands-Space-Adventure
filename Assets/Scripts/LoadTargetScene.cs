using UnityEngine;
using System.Collections;

public class LoadTargetScene : MonoBehaviour {


    public void LoadSceneNum(int num){
    
        LoadingScreenManager.LoadScene(num);
    }

    public void GameoverScene()
    {
        StartCoroutine(loadGameOverScene());
    }

    IEnumerator loadGameOverScene()
    {
        yield return new WaitForSeconds(5f);
        LoadSceneNum(6);
    }

}
