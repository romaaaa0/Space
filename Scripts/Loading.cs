using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class Loading : MonoBehaviour
    {
        [SerializeField] private Text percentText;
        [SerializeField] private Image slider;
        private void Update()
        {
            LoadingScene();
        }
        private void LoadingScene()
        {
            slider.fillAmount += Time.deltaTime;
            int percent = Mathf.RoundToInt(slider.fillAmount);
            percentText.text = Mathf.Round(slider.fillAmount * 100).ToString() + "%";
            if (slider.fillAmount >= 1)
                Scene.Menu();
        }
    }
}
