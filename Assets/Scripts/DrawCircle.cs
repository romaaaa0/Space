using UnityEngine;
namespace Assets
{
    using UnityEngine;

    [RequireComponent(typeof(LineRenderer))]
    public class DrawCircle : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private Color lineColor = Color.blue;
        [SerializeField] private float lineWidth = 0.1f;
        private int numPoints = 100;
        private LineRenderer lineRenderer;

        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Standard"));
            lineRenderer.material.color = lineColor;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
            DrawCircleShape();
        }

        void DrawCircleShape()
        {
            lineRenderer.positionCount = numPoints + 1;
            lineRenderer.useWorldSpace = false;

            float deltaTheta = (2f * Mathf.PI) / numPoints;
            float theta = 0f;

            for (int i = 0; i < numPoints + 1; i++)
            {
                float x = radius * Mathf.Cos(theta);
                float z = radius * Mathf.Sin(theta);

                lineRenderer.SetPosition(i, new Vector3(x, 0f, z));

                theta += deltaTheta;
            }
        }
    }
}
