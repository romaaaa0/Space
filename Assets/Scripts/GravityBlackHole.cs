using System;
using UnityEngine;

namespace Assets
{
    public class GravityBlackHole : MonoBehaviour, IGravity
    {
        public float ForceOfGravity
        {
            get
            {
                if (forceOfGravity < 0) throw new ArgumentException();
                return forceOfGravity;
            }
            set
            {
                if (forceOfGravity < 0) throw new ArgumentException();
                forceOfGravity = value;
            }
        }
        private float forceOfGravity = 100;
        private void Start()
        {
            forceOfGravity += PlayerPrefs.GetFloat("ForceOfGravityBlackHole");
        }
    }
}
