using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    private Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 0) return;
        float time = Time.time;

        float x = Mathf.Cos(time * speed) * radius;
        float z = Mathf.Sin(time * speed) * radius;

        transform.position = new Vector3(startPosition.x + x, 0f, startPosition.z + z);
    }
}
