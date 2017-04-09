using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class AddManager : MonoBehaviour {

    public static AddManager Instance {get;set;}

    string bannerID = "ca-app-pub-2151861431834316/6320052583";
    string videoID = "ca-app-pub-2151861431834316/5262121786"; // interstial

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

    }

    void Start()
    {
        Admob.Instance().initAdmob(bannerID, videoID); //set your admob id here
       // Admob.Instance().setTesting(true);
        Admob.Instance().loadInterstitial();
    }

    public void showBanner()
    {
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 5);
    }

    public void showVideoAdd()
    {
        if (Admob.Instance().isInterstitialReady())
        {
            Admob.Instance().showInterstitial();
        }
    }


}
