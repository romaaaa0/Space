using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets
{
    public class CreatorMeteorite : MonoBehaviour
    {
        [SerializeField] private GameObject meteorite;
        [SerializeField] private int numberOfMeteorite;
        [SerializeField] private Timer timer;
        private List<Vector3> busyPosition = new List<Vector3>();
        private int minPositionX = -7;
        private int maxPositionX = 4;
        private int minPositionZ = 25;
        private int maxPositionZ = 12;
        private bool canFunctionWork = true;

        private void Start()
        {
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
                        Instantiate(meteorite, position, Quaternion.identity);
                        busyPosition.Add(position);
                    }
                }

                yield return new WaitForSeconds(10);
            }
        }
    }
}