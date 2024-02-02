using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class Attraction : MonoBehaviour
    {
        private TimerOfGravity timerOfGravity;
        private void Start()
        {
            if (GetComponent<TimerOfGravity>())
                timerOfGravity = GetComponent<TimerOfGravity>();
        }
        public void ApplyGravity(Transform attractor, Transform meteorite, float forceOfGravity, Rigidbody rigidbody)
        {
            if (timerOfGravity != null && timerOfGravity.IsGravityOn == false) return;
            else if (PlayerPrefs.GetInt("Tutorial") == 0) return;
            var direction = attractor.position - meteorite.position;
            var distance = direction.magnitude;

            var gravityForce = direction.normalized * (forceOfGravity / Mathf.Pow(distance, 2));

            rigidbody.AddForce(gravityForce, ForceMode.Acceleration);
        }

    }
}

