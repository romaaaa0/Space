using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class Timer : MonoBehaviour
    {
        public bool IsTimeIsUp { get; private set; }
        [SerializeField] private int startTime;
        [SerializeField] private Image timerImage;
        private float timer;
        private float result;
        private void Start()
        {
            timer = startTime;
        }
        private void Update()
        {
            if (PlayerPrefs.GetInt("Tutorial") == 0) return;
            if (timer <= 0)
            {
                IsTimeIsUp = true;
                return;
            }
            timer -= Time.deltaTime;
            result = timer / startTime;
            timerImage.fillAmount = result;
        }

    }
}
