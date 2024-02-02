using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class AttractionPlanet : MonoBehaviour
    {
        [SerializeField] private bool isAttractionEnabled;
        private Transform planet;
        private float forceOfGravity;
        private Attraction attraction;
        private Rigidbody rigidbodyMeteoride;
        private void Start()
        {
            rigidbodyMeteoride = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            if (isAttractionEnabled)
            {
                attraction.ApplyGravity(planet, transform, forceOfGravity, rigidbodyMeteoride);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Attraction>())
            {
                attraction = other.gameObject.GetComponent<Attraction>();
                isAttractionEnabled = true;
                planet = other.gameObject.transform;
                forceOfGravity = other.gameObject.GetComponent<IGravity>().ForceOfGravity;
            }
            else if (other.gameObject.GetComponent<Planet>())
            {
                isAttractionEnabled = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<IGravity>() != null)
            {
                isAttractionEnabled = false;
                planet = null;
            }
        }
    }
}
