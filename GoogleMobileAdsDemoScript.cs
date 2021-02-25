
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GoogleMobileAdsDemoScript : MonoBehaviour
{
    private RewardBasedVideoAd rewardBasedVideo;
    public GameObject panel;
    float timing=0f;
    private readonly string AppID_android = "ca-app-pub-7994185844941166~7411883718";
    private readonly string AppID_aiphone = "ca-app-pub-7994185844941166~9557572425";
    public GameObject player;
    private int hart_count = 0;
    public Text coins;
    [Obsolete]
    public void Start()
    {
#if UNITY_ANDROID
        MobileAds.Initialize(AppID_android);
#elif UNITY_IPHONE
        MobileAds.Initialize(AppID_aiphone);
#else
        MobileAds.Initialize("Not non");
#endif

        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        rewardBasedVideo.OnAdLoaded -= HandleRewardBasedVideoLoaded;
        rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed -= HandleRewardBasedVideoClosed;
        if (!InternetCheck())
        {
            panel.SetActive(false);
        }


        if (SceneManager.GetActiveScene().name == "START_1")
        {
            
            if (PlayerPrefs.GetInt("Ad") == 0) {
                rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
                rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
                rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
                rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
                this.RequestRewardBasedVideo(); }
            else { panel.SetActive(false); }
        }
        else
        {
            rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
            rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
            rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
            this.RequestRewardBasedVideo();
        }
        if (SceneManager.GetActiveScene().name == "Bunos")
        {
            coins.text = "COINS = " + PlayerPrefs.GetInt("banana");
        }
    }

    public void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7994185844941166/7694187807";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-7994185844941166/8024998909";
#else
        string adUnitId = "NON";
#endif

        //string adUnitId_test = "ca-app-pub-3940256099942544/5224354917";
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardBasedVideo.LoadAd(request, adUnitId);


    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {

    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

        RequestRewardBasedVideo();
    }


    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {

        if (SceneManager.GetActiveScene().name != "Bunos" &&
            SceneManager.GetActiveScene().name != "Level_INTRO" &&
            SceneManager.GetActiveScene().name != "Levels" &&
            SceneManager.GetActiveScene().name != "shop" &&
            SceneManager.GetActiveScene().name != "START_1" &&
            SceneManager.GetActiveScene().name != "FINAL")
        {
            RequestRewardBasedVideo();
        }
        if (SceneManager.GetActiveScene().name == "START_1")
        {
            rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
            rewardBasedVideo.OnAdClosed -= HandleRewardBasedVideoClosed;
            this.UserOptToWatchAd();
        }
        if (SceneManager.GetActiveScene().name == "Bunos")
        {
            rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
            rewardBasedVideo.OnAdClosed -= HandleRewardBasedVideoClosed;
        }
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {

        rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
        if (SceneManager.GetActiveScene().name != "Bunos" &&
            SceneManager.GetActiveScene().name != "Level_INTRO" &&
            SceneManager.GetActiveScene().name != "Levels" &&
            SceneManager.GetActiveScene().name != "shop" &&
            SceneManager.GetActiveScene().name != "START_1" &&
            SceneManager.GetActiveScene().name != "FINAL")
        {
            hart_count++;
            player.GetComponent<player_collection>().show_to_get_hart();
            rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
            RequestRewardBasedVideo();
        }
        if(SceneManager.GetActiveScene().name == "Bunos")
        {
            int value_b = PlayerPrefs.GetInt("banana") + PlayerPrefs.GetInt("bunos");
            PlayerPrefs.SetInt("banana", value_b);
            coins.text = "COINS = " + value_b;
            //rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
            //rewardBasedVideo.OnAdClosed -= HandleRewardBasedVideoClosed;
            SceneManager.LoadScene("Levels");
        }
        if(SceneManager.GetActiveScene().name == "START_1")
        {
            rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
            rewardBasedVideo.OnAdClosed -= HandleRewardBasedVideoClosed;
            PlayerPrefs.SetInt("Ad", 1);
        }
        
    }
 public void playe_buttom() 
    {
        if (PlayerPrefs.GetInt("Ad") == 0)
        {
            UserOptToWatchAd();
        }
    }
    public void UserOptToWatchAd()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
    }
    private bool InternetCheck()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void OK()
    {
        rewardBasedVideo.Show();
        
    }
    public void NO()
    {
        SceneManager.LoadScene("Levels");
        rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed -= HandleRewardBasedVideoClosed;
    }
    private void Update()
    {
        timing += Time.deltaTime;
        if (timing > 6f && SceneManager.GetActiveScene().name == "START_1")
        {
            panel.SetActive(false);
        }
    }
    public void show_to_get_hart()
    {
        if (hart_count > 2)
        {

        }
        else
        {
            UserOptToWatchAd();
        }

    }
    public void reset_close()
    {
        rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed -= HandleRewardBasedVideoClosed;
    }
    
}
