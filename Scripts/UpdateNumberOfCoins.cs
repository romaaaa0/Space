using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class UpdateNumberOfCoins : MonoBehaviour
    {
        [SerializeField] private Text numberCoinsText;
        private void Start()
        {
            numberCoinsText.text = PlayerPrefs.GetInt("Coins").ToString();
        }
    }
}
