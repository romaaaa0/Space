using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private BlackHole blackHole;
        [SerializeField] private CollectMeteorite collectMeteorite;
        [SerializeField] private Timer timer;
        private bool canFunctionWork = true;

        private void Update()
        {
            if (timer.IsTimeIsUp && collectMeteorite.NumberOfMeteorites < blackHole.RequestAmountMeteorite &&
                canFunctionWork)
            {
                StartCoroutine(LostGame());
                canFunctionWork = false;
            }
        }

        private IEnumerator LostGame()
        {
            Information.GameIsOff = true;
            gameOverPanel.SetActive(true);
            yield return new WaitForSeconds(2);
            Information.GameIsOff = false;
            Scene.Menu();
        }
    }
}