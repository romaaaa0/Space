using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class TimerOfGravity : MonoBehaviour
    {
        public bool IsGravityOn { get; private set; }
        [SerializeField] private Text timerText;
        [SerializeField] private float startTime;
        private float timer;
        private void Start()
        {
            timer = startTime;
        }
        private void Update()
        {
            if (PlayerPrefs.GetInt("Tutorial") == 0) return;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                IsGravityOn = false;
            }
            else
            {
                IsGravityOn = true;
                timerText.text = Mathf.Round(timer).ToString();
            }
        }
    }
}
