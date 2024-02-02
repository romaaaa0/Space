using System;
using UnityEngine;

namespace LevelsLoad
{
    public class LevelsScroll : MonoBehaviour
    {
        [SerializeField] private LevelItem _levelItem;

        [SerializeField] private Transform _content;

        [SerializeField] private Sprite[] _sprites;
        
        
        private void Awake()
        {
            foreach (Transform item in _content)
            {
                Destroy(item.gameObject);
            }


            //InitVal

            for (int i = 1; i <= 200; i++)
            {
                var item = Instantiate(_levelItem, _content);


                int levelNumber = (i % 10) + 1;


                Sprite
                    selectedSprite =
                        _sprites[
                            i % _sprites.Length];

                item.IniLevel(levelNumber, selectedSprite, i);
            }
        }
    }
}