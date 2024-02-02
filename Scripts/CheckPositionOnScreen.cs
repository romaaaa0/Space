using UnityEngine;

namespace Assets
{
    public class CheckPositionOnScreen : MonoBehaviour
    {
        private int screenWidth;
        private Vector3 positionOnScreen;
        private void Start()
        {
            screenWidth = Screen.width;
        }
        private void Update()
        {
            positionOnScreen = Camera.main.WorldToScreenPoint(transform.position);
            if (positionOnScreen.x > screenWidth || positionOnScreen.x < 0)
                Destroy(gameObject);
        }
    }
}
