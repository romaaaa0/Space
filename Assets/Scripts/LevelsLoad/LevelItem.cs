using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LevelsLoad
{
    public class LevelItem : MonoBehaviour
    {
        [SerializeField] private Text[] _textLevels;
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        [Space] [SerializeField] private AudioSource audioSource;

        private int _numberLevel;

        private void OnEnable()
        {
            _button.onClick.AddListener(LoadLevel);
        }

        public void IniLevel(int number, Sprite icon, int levelNumber)
        {
            _numberLevel = number;
            _image.sprite = icon;

            for (int i = 0; i < _textLevels.Length; i++)
            {
                _textLevels[i].text = $"Level {levelNumber}";
            }
        }

        private void LoadLevel()
        {
            audioSource.Play();
            SceneManager.LoadScene("Level " + _numberLevel);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}