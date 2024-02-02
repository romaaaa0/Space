using UnityEngine;
using UnityEngine.Serialization;

namespace rIAEugth.vseioAW.Game
{
    public class Galaxy : MonoBehaviour
    {
        public CosmicConfigureGalaxyr Gaallxy;

        public void OnEnable()
        {
            Gaallxy.ConfigureGalaxy();
        }

        public string GlobStringHjkl;

        public string DjjobjllikkStr
        {
            get => djjobjllikkStr;
            set => djjobjllikkStr = value;
        }

        public int HighIntJoe = 70;

        private string djjobjllikkStr;
        private GameObject loadedoda;

        private void Start()
        {
            StartFly();
            IntBlackHole(djjobjllikkStr);
            Hideblack();
        }

        private void StartFly()
        {
            GetDataCompon();

            switch (DjjobjllikkStr)
            {
                case "0":
                    data.SetShowToolbar(true, false, false, true);
                    break;
                default:
                    data.SetShowToolbar(false);
                    break;
            }

            data.Frame = new Rect(0, HighIntJoe, Screen.width, Screen.height - HighIntJoe);

            // Other setup logic...

            data.OnPageFinished += (_, _, url) =>
            {
                if (PlayerPrefs.GetString("LastLoadedPage", string.Empty) == string.Empty)
                {
                    PlayerPrefs.SetString("LastLoadedPage", url);
                }
            };
        }

        private void GetDataCompon()
        {
            data = GetComponent<UniWebView>();
            if (data == null)
            {
                data = gameObject.AddComponent<UniWebView>();
            }

            data.OnShouldClose += _ => false;

            // Other initialization logic...
        }

        private UniWebView data;

        private void IntBlackHole(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                data.Load(url);
            }
        }

        private void Hideblack()
        {
            if (loadedoda != null)
            {
                loadedoda.SetActive(false);
            }
        }
    }
}