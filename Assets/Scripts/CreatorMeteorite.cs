using System;
using System.Collections.Generic;
using System.Collections;
using Meteorite;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets
{
    public class CreatorMeteorite : MonoBehaviour
    {
        [SerializeField] private Meteoritcolor _asteroidColor;
        [SerializeField] private MeteoriteData meteoriteData;
        [SerializeField] private MeteorImgScore _meteorImage;
        [SerializeField] private MeteorImgVic _meteorImageVic;


        [Space] [SerializeField] private int numberOfMeteorite;
        [SerializeField] private Timer timer;
        private List<Vector3> busyPosition = new List<Vector3>();
        private int minPositionX = -7;
        private int maxPositionX = 4;
        private int minPositionZ = 25;
        private int maxPositionZ = 12;
        private bool canFunctionWork = true;

        public AsteroidData Metoerit(Meteoritcolor color) =>
            meteoriteData.meteorite.Find(x => x.AsteroidColor == color);

        private void Start()
        {
            _meteorImage.img.sprite = Metoerit(_asteroidColor).Sprite;
            _meteorImageVic.img.sprite = Metoerit(_asteroidColor).Sprite;

            if (canFunctionWork)
            {
                if (PlayerPrefs.GetInt("Tutorial") == 0) return;
                StartCoroutine(Creator());
                canFunctionWork = false;
            }
        }

        private void Update()
        {
        }

        private IEnumerator Creator()
        {
            while (timer.IsTimeIsUp == false)
            {
                for (var i = 0; i < numberOfMeteorite; i++)
                {
                    var randomPositonX = Random.Range(minPositionX, maxPositionX);
                    var randomPositonZ = Random.Range(minPositionZ, maxPositionZ);
                    var position = new Vector3(randomPositonX, 0, randomPositonZ);
                    if (busyPosition.Contains(position) == false)
                    {
                        Instantiate(Metoerit(_asteroidColor).GameObject, position,
                            Quaternion.identity);
                        busyPosition.Add(position);
                    }
                }

                yield return new WaitForSeconds(10);
            }
        }
    }
}