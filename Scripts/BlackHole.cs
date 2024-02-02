using UnityEngine;

namespace Assets
{
    public class BlackHole : MonoBehaviour
    {
        public int RequestAmountMeteorite { get { return requestAmountMeteorite; } }
        [SerializeField] private int requestAmountMeteorite;
        private void Start()
        {
            var scale = PlayerPrefs.GetFloat("ScaleBlackHole");
            if (scale == 0) return;
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
