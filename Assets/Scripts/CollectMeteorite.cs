using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class CollectMeteorite : MonoBehaviour       
    {
        public int NumberOfMeteorites { get; private set; }
        [SerializeField] private Text numberOfMeteoritesText;
        [SerializeField] private CollectCoins collectCoins;
        [SerializeField] private AudioSource successAudio;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<IMeteorite>() != null)
            {
                Collect(other.gameObject);
                collectCoins.Collect();
            }
        }
        private void Collect(GameObject meteorite)
        {
            if (!Information.GameIsOff)
            {
                NumberOfMeteorites++;
                numberOfMeteoritesText.text = NumberOfMeteorites.ToString();
                successAudio.Play();
                Destroy(meteorite);
            }
        }
    }
}
