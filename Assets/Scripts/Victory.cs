using System.Collections;
using UnityEngine;

namespace Assets
{
    public class Victory : MonoBehaviour
    {
        [SerializeField] private BlackHole blackHole;
        [SerializeField] private GameObject victoryPanel;
        [SerializeField] private CollectMeteorite collectMeteorite;
        private Timer timer;
        private bool canFunctionWork = true;
        private void Start()
        {
            timer = GetComponent<Timer>();
        }
        private void Update()
        {
            if (timer.IsTimeIsUp && collectMeteorite.NumberOfMeteorites >= blackHole.RequestAmountMeteorite && canFunctionWork)
            {
                StartCoroutine(VictoryGame());
                canFunctionWork = false;
            }
        }
        private IEnumerator VictoryGame()
        {
            Information.GameIsOff = true;
            victoryPanel.SetActive(true);
            yield return new WaitForSeconds(2);
            Information.GameIsOff = false;
            Scene.Menu();
        }
    }
}
