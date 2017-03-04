using UnityEngine;
using System.Collections;

public class LoadTargetScene : MonoBehaviour {

    public void LoadSceneNum(int num){
        LoadingScreenManager.LoadScene(num);
    }

}
