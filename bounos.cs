using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bounos : MonoBehaviour
{
    private RewardBasedVideoAd rewardBasedVideo;
    public Text text;
    public GameObject panel;
    public GameObject ok;
    public GameObject no;
    bool show = true;
    string AppID = "ca-app-pub-7994185844941166~7411883718";
    [Obsolete]
    public void Start()
    {
        text.text = "WAIT.....";
            this.rewardBasedVideo = RewardBasedVideoAd.Instance;

            // Called when an ad request has successfully loaded.
            rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
            // Called when an ad request failed to load.
            rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
            // Called when an ad is shown.
            rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
            // Called when the ad starts to play.
            rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
            // Called when the user should be rewarded for watching a video.
            rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
            // Called when the ad is closed.
            rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
            // Called when the ad click caused the user to leave the application.
            rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
            this.RequestRewardBasedVideo();

    }

    public void RequestRewardBasedVideo()
    {
        //string adUnitId = "ca-app-pub-7994185844941166/6645596950";/////orginal
        //string adUnitId = "ca-app-pub-7994185844941166/6995733126";/////second
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";////test

            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the rewarded video ad with the request.
            this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        text.text = "HandleRewardBasedVideoLoaded event received";
            panel.SetActive(false);
            ok.SetActive(true);
            no.SetActive(true);

    }
    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        text.text = "HandleRewardBasedVideoFailedToLoad";
        RequestRewardBasedVideo();
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {

    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {

    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        text.text = "HandleRewardBasedVideoClosed";
        this.RequestRewardBasedVideo();
        PlayerPrefs.SetInt("banana", (PlayerPrefs.GetInt("banana") + PlayerPrefs.GetInt("bunos")));
        SceneManager.LoadScene("Levels");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        text.text = "HandleRewardBasedVideoRewarded";

        RequestRewardBasedVideo();


    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {

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
        UserOptToWatchAd();
    }
    public void NO()
    {
        SceneManager.LoadScene("Levels");
    }

}
