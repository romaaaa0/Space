using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppsFlyerSDK;

// This class is intended to be used the the AppsFlyerObject.prefab

public class AppsFlyerObjectScript : MonoBehaviour, IAppsFlyerConversionData
{
    private readonly string dataGet = "campaign";
    private readonly string dataset = "&";


    // These fields are set from the editor so do not modify!
    //******************************//
    public string devKey;
    public string appID;
    public string UWPAppID;
    public string macOSAppID;
    public bool isDebug;

    public bool getConversionData;
    //******************************//


    void Start()
    {
        // These fields are set from the editor so do not modify!
        //******************************//
        AppsFlyer.setIsDebug(isDebug);
#if UNITY_WSA_10_0 && !UNITY_EDITOR
        AppsFlyer.initSDK(devKey, UWPAppID, getConversionData ? this : null);
#elif UNITY_STANDALONE_OSX && !UNITY_EDITOR
    AppsFlyer.initSDK(devKey, macOSAppID, getConversionData ? this : null);
#else
        AppsFlyer.initSDK(devKey, appID, getConversionData ? this : null);
#endif
        //******************************/

        AppsFlyer.startSDK();
    }


    void Update()
    {
    }

    // Mark AppsFlyer CallBacks
    public void onConversionDataSuccess(string conversionData)
    {
        AppsFlyer.AFLog("didReceiveConversionData", conversionData);
        Dictionary<string, object> datas = AppsFlyer.CallbackStringToDictionary(conversionData);

        var findOfIndex = "";

        var savePPData = "";
        if (datas.ContainsKey(dataGet))
        {
            if (datas.TryGetValue(dataGet, out var campaignValue))
            {
                string[] subParams = campaignValue.ToString().Split('_');
                if (subParams.Length > 0)
                {
                    savePPData = dataset;
                    for (var i = 0; i < subParams.Length; i++)
                    {
                        savePPData += $"sub{(i + 1)}={subParams[i]}";
                        if (i < subParams.Length - 1)
                        {
                            savePPData += dataset;
                        }
                    }
                }
            }
        }

// Add deferred deeplink logic here
        PlayerPrefs.SetString("Result", savePPData);
    }

    public void onConversionDataFail(string error)
    {
        AppsFlyer.AFLog("didReceiveConversionDataWithError", error);
        PlayerPrefs.SetString("Result", "");
    }

    public void onAppOpenAttribution(string attributionData)
    {
        AppsFlyer.AFLog("onAppOpenAttribution", attributionData);
        Dictionary<string, object> attributionDataDictionary = AppsFlyer.CallbackStringToDictionary(attributionData);
        PlayerPrefs.SetString("Result", "");
        // add direct deeplink logic here
    }

    public void onAppOpenAttributionFailure(string error)
    {
        AppsFlyer.AFLog("onAppOpenAttributionFailure", error);
        PlayerPrefs.SetString("Result", "");
    }
}