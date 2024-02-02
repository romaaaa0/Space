using UnityEngine;

namespace Assets
{
    public class MeteoriteShift : MonoBehaviour
    {
        [SerializeField] private float force;
        private Rigidbody rigidbodyMeteorite;
        private void Start()
        {
            rigidbodyMeteorite = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            Shift();
        }
        private void Shift()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var point = hit.point;
                    var direction = point - transform.position;
                    var normalizedDirection = direction.normalized;
                    rigidbodyMeteorite.AddForce(new Vector3(normalizedDirection.x, 0, 0) * force);
                }
            }

        }
    }
}
