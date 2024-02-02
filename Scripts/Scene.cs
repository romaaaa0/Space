using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class Scene : MonoBehaviour
    {
        public static void Looding()
        {
            SceneManager.LoadScene(0);
        }
        public static void ChooseLevels()
        {
            SceneManager.LoadScene(1);
        }
        public static void Menu()
        {
            SceneManager.LoadScene(2);
            if (PlayerPrefs.GetInt("Level") == 0)
                PlayerPrefs.SetInt("Level", 1);
        }
        public static void Upgrade()
        {
            SceneManager.LoadScene(3);
        }
        public static void LoadGame()
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        }
    }
}
