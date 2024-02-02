using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class NumberOfCollectCoins : MonoBehaviour
    {
        [SerializeField] private CollectCoins collectCoins;
        private Text coinsText;
        private void Start()
        {
            coinsText = GetComponent<Text>();
            coinsText.text = collectCoins.NumberOfCollectCoins.ToString();
        }
    }
}
