using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class CollectCoins : MonoBehaviour
    {
        public int NumberOfCollectCoins { get; private set; }
        [SerializeField] private Text coinsText;
        public void Collect()
        {
            var price = 50;
            NumberOfCollectCoins += price;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + price);
            coinsText.text = PlayerPrefs.GetInt("Coins").ToString();
        }
    }
}
