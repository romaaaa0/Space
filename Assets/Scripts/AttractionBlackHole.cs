using UnityEngine;

namespace Assets
{

    public class AttractionBlackHole : MonoBehaviour
    {
        private Transform attractor;
        private float forceOfGravity;
        private Attraction attraction;
        private Rigidbody rigidbodyMeteoride;
        private void Start()
        {
            rigidbodyMeteoride = GetComponent<Rigidbody>();
            attractor = FindObjectOfType<BlackHole>().transform;
            attraction = attractor.gameObject.GetComponent<Attraction>();
            forceOfGravity = attractor.gameObject.GetComponent<IGravity>().ForceOfGravity;
        }
        private void FixedUpdate()
        {
            if (Information.GameIsOff) return;
            attraction.ApplyGravity(attractor, transform, forceOfGravity, rigidbodyMeteoride);
        }
    }
}