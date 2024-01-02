using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    [SerializeField] private BannerAd bannerAd;
    string _adUnitId;
    [SerializeField] private int timeToSkip = 2;



    void Awake()
    {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
        /* Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;*/

        int skipNumber = PlayerPrefs.GetInt("Interstitial", timeToSkip);
        if (skipNumber != 0)
        {
            skipNumber -= 1;
            PlayerPrefs.SetInt("Interstitial", skipNumber);
        }
        else
        {
            LoadAd();
            PlayerPrefs.SetInt("Interstitial", timeToSkip);
        }


    }
    void Start()

    {

    }

    public void LoadAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(_adUnitId, this);
        }
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
    }


    public void OnUnityAdsAdLoaded(string placementId)
    {
        ShowAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Failed");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Show Complated");
        Time.timeScale = 1;
        bannerAd.LoadBannerAd();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Show Failure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Show Start");
        Advertisement.Banner.Hide();
        Time.timeScale = 0;
    }
}
