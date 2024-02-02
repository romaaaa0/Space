using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class Loading : MonoBehaviour
    {
        [SerializeField] private Text percentText;
        [SerializeField] private Image slider;

        private float loadingDuration = 8f; // Total duration of the loading process in seconds
        private float startTime; // Time when the loading process starts

        private void Start()
        {
            startTime = Time.time; // Initialize startTime when the scene starts or loading begins
        }

        private void Update()
        {
            LoadingScene();
        }

        private void LoadingScene()
        {
            // Calculate the elapsed time since the loading started
            float timeElapsed = Time.time - startTime;
    
            // Calculate the fill amount based on the elapsed time and total duration
            slider.fillAmount = Mathf.Clamp(timeElapsed / loadingDuration, 0, 1);
    
            // Update the percentage text
            int percent = Mathf.RoundToInt(slider.fillAmount * 100);
            percentText.text = percent.ToString() + "%";
    
            // If loading is complete, change the scene
            if (slider.fillAmount >= 1)
            {
                Scene.Menu(); // Make sure Scene.Menu() is a valid call to change the scene
            }
        }

    }
}
