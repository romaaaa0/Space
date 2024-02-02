using System.Collections;
using UnityEngine;

namespace _Project.Scripts.Game.Camera.Controllers
{
    public class CameraSize : MonoBehaviour
    {
         public Vector2 DefaultResolution = new Vector2(720, 1280);
        [Range(0f, 1f)] public float WidthOrHeight = 0;

        [SerializeField] private UnityEngine.Camera _componentCamera;

        private float SizeStart;
        private float SizeNeed;

        private float Fov;
        private float HorFov = 120f;

        private void Start()
        {
            SizeStart = _componentCamera.orthographicSize;

            SizeNeed = DefaultResolution.x / DefaultResolution.y;

            Fov = _componentCamera.fieldOfView;
            HorFov = CalcVerticalFov(Fov, 1 / SizeNeed);
        }

        private void Update()
        {
            if (_componentCamera.orthographic)
            {
                float constantWidthSize = SizeStart * (SizeNeed / _componentCamera.aspect);
                _componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, SizeStart, WidthOrHeight);
            }
            else
            {
                float constantWidthFov = CalcVerticalFov(HorFov, _componentCamera.aspect);
                _componentCamera.fieldOfView = Mathf.Lerp(constantWidthFov, Fov, WidthOrHeight);
            }
        }

        private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
        {
            float hFovInRads = hFovInDeg * Mathf.Deg2Rad;

            float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);

            return vFovInRads * Mathf.Rad2Deg;
        }
    }
}