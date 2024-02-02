using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class Tutotial : MonoBehaviour
    {
        [SerializeField] private List<string> explainText = new List<string>();
        [SerializeField] private Text tutorialText;
        [SerializeField] private GameObject tutorialPanel;
        private void Start()
        {
            if (PlayerPrefs.GetInt("Tutorial") == 0)
            {
                StartCoroutine(ExplainGame());
            }
        }
        private IEnumerator ExplainGame()
        {
            tutorialPanel.SetActive(true);
            for (var i = 0; i < explainText.Count; i++)
            {
                tutorialText.text = explainText[i];
                yield return new WaitForSeconds(3);
            }
            PlayerPrefs.SetInt("Tutorial", 1);
            tutorialPanel.SetActive(false);
        }
    }
}
