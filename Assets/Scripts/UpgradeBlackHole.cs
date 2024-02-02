using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class UpgradeBlackHole : MonoBehaviour
    {
        [SerializeField] private GameObject blackHole;
        [SerializeField] private Text priceText;
        [SerializeField] private Text maximumUpgradeText;
        [SerializeField] private Text coinsText;
        [SerializeField] private GameObject crystal;
        [SerializeField] private GameObject popup;
        private int price = 50;
        private int stageUpgrade = 0;
        private int maxStageUpgrade = 10;
        private void Start()
        {
            stageUpgrade = PlayerPrefs.GetInt("StageUpgrade");
            if (stageUpgrade == 0) return;
            var scale = PlayerPrefs.GetFloat("ScaleBlackHole");
            blackHole.transform.localScale = new Vector3(scale, scale, scale);
            price = PlayerPrefs.GetInt("PriceUpgradeBlackHole");
            priceText.text = price.ToString();
            if (stageUpgrade >= maxStageUpgrade)
            {
                maximumUpgradeText.gameObject.SetActive(true);
                priceText.gameObject.SetActive(false);
                crystal.gameObject.SetActive(false);
            }
        }
        public void Upgrade()
        {
            if(PlayerPrefs.GetInt("Coins") > price && stageUpgrade < maxStageUpgrade)
            {
                PlayerPrefs.SetFloat("ForceOfGravityBlackHole", PlayerPrefs.GetFloat("ForceOfGravityBlackHole") + 20);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - price);
                stageUpgrade++;
                blackHole.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                price *= 2;
                priceText.text = price.ToString();
                PlayerPrefs.SetInt("PriceUpgradeBlackHole", price);
                PlayerPrefs.SetFloat("ScaleBlackHole", blackHole.transform.localScale.x);
                PlayerPrefs.SetInt("StageUpgrade", stageUpgrade);
                coinsText.text = PlayerPrefs.GetInt("Coins").ToString();
            }
            else if(PlayerPrefs.GetInt("Coins") < price)
            {
                popup.SetActive(true);
            }
            if(stageUpgrade >= maxStageUpgrade)
            {
                maximumUpgradeText.gameObject.SetActive(true);
                priceText.gameObject.SetActive(false);
                crystal.gameObject.SetActive(false);
            }
        }
    }
}
