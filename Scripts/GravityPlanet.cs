using UnityEngine;
using System;

namespace Assets
{
    public class GravityPlanet : MonoBehaviour, IGravity
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
        [SerializeField] private float forceOfGravity;
    }
}
