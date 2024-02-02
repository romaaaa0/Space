using System.Collections;
using System.Collections.Generic;
using AppsFlyerSDK;
using rIAEugth.vseioAW.Game;
using Unity.Advertisement.IosSupport;
using UnityEngine;
using UnityEngine.Networking;

namespace rIAEugth.vseioAW.segAIWUt
{
    public class SpaceResultPoopIjh : MonoBehaviour
    {
        [SerializeField] private Galaxy _eventHorizon;
        [SerializeField] private IDFAController _cosmicIDFACheck;

        [SerializeField] private StarConcatenator starConcatenator;

        private bool isFirstSingularity = true;
        private NetworkReachability cosmicConnectivity = NetworkReachability.NotReachable;

        private string starCoordinate1 { get; set; }
        private string starCoordinate2;
        private int starMass;

        private string quantumSignature;


        private string stellarLabel;

        private void Awake()
        {
            HandleMultipleUniverses();
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            _cosmicIDFACheck.ScrutinizeIDFA();
            StartCoroutine(FetchGalacticID());

            switch (Application.internetReachability)
            {
                case NetworkReachability.NotReachable:
                    HandleVoidConnection();
                    break;
                default:
                    CheckStoredData();
                    break;
            }
        }

        private void HandleMultipleUniverses()
        {
            switch (isFirstSingularity)
            {
                case true:
                    isFirstSingularity = false;
                    break;
                default:
                    gameObject.SetActive(false);
                    break;
            }
        }

        private IEnumerator FetchGalacticID()
        {
#if UNITY_IOS
            var authorizationStatus = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
            while (authorizationStatus == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
            {
                authorizationStatus = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
                yield return null;
            }
#endif

            quantumSignature = _cosmicIDFACheck.RetrieveAdvertisingID();
            yield return null;
        }

        private void CheckStoredData()
        {
            if (PlayerPrefs.GetString("top", string.Empty) != string.Empty)
            {
                LoadStoredData();
            }
            else
            {
                FetchDataFromServerWithDelay();
            }
        }

        private void LoadStoredData()
        {
            starCoordinate1 = PlayerPrefs.GetString("top", string.Empty);
            starCoordinate2 = PlayerPrefs.GetString("top2", string.Empty);
            starMass = PlayerPrefs.GetInt("top3", 0);
            AbsorbNebulaData();
        }

        private void FetchDataFromServerWithDelay()
        {
            Invoke(nameof(ReceiveData), 7.4f);
        }

        private void ReceiveData()
        {
            if (Application.internetReachability == cosmicConnectivity)
            {
                HandleVoidConnection();
            }
            else
            {
                StartCoroutine(FetchDataServeradoColorado());
            }
        }

        [SerializeField] private List<string> galaxyTokens;
        [SerializeField] private List<string> nebulaDetails;

        private IEnumerator FetchDataServeradoColorado()
        {
            using UnityWebRequest webRequest =
                UnityWebRequest.Get(starConcatenator.MergeStellarFragments(nebulaDetails));
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.DataProcessingError)
            {
                HandleVoidConnection();
            }
            else
            {
                AnalyzeCosmicResponse(webRequest);
            }
        }

        private void AnalyzeCosmicResponse(UnityWebRequest webRequest)
        {
            string tokenConcatenation = starConcatenator.MergeStellarFragments(galaxyTokens);

            if (webRequest.downloadHandler.text.Contains(tokenConcatenation))
            {
                try
                {
                    string[] dataParts = webRequest.downloadHandler.text.Split('|');
                    PlayerPrefs.SetString("top", dataParts[0]);
                    PlayerPrefs.SetString("top2", dataParts[1]);
                    PlayerPrefs.SetInt("top3", int.Parse(dataParts[2]));

                    starCoordinate1 = dataParts[0];
                    starCoordinate2 = dataParts[1];
                    starMass = int.Parse(dataParts[2]);
                }
                catch
                {
                    PlayerPrefs.SetString("top", webRequest.downloadHandler.text);
                    starCoordinate1 = webRequest.downloadHandler.text;
                }

                AbsorbNebulaData();
            }
            else
            {
                HandleVoidConnection();
            }
        }

        private void AbsorbNebulaData()
        {
            _eventHorizon.DjjobjllikkStr = $"{starCoordinate1}?idfa={quantumSignature}";
            _eventHorizon.DjjobjllikkStr +=
                $"&gaid={AppsFlyer.getAppsFlyerId()}{PlayerPrefs.GetString("Result", string.Empty)}";
            _eventHorizon.GlobStringHjkl = starCoordinate2;


            ActivateWormhole();
        }

        public void ActivateWormhole()
        {
            _eventHorizon.HighIntJoe = starMass;
            _eventHorizon.gameObject.SetActive(true);
        }

        private void HandleVoidConnection()
        {
            print("NO_DATA");

            DisableSpaceFabric();
        }

        private void DisableSpaceFabric()
        {
            gameObject.SetActive(false);
        }

        // Add the rest of your methods as needed...
    }
}