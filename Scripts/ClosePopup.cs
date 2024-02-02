using UnityEngine;

namespace Assets
{
    public class ClosePopup : MonoBehaviour
    {
        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
