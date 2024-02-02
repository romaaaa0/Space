using UnityEngine;

namespace Assets
{
    public class SetLevel : MonoBehaviour
    {

        public void SetLevel1()
        {
            PlayerPrefs.SetInt("Level", 4);
            Scene.LoadGame();
        }
        public void SetLevel2()
        {
            PlayerPrefs.SetInt("Level", 5);
            Scene.LoadGame();
        }
        public void SetLevel3()
        {
            PlayerPrefs.SetInt("Level", 6);
            Scene.LoadGame();
        }
    }
}
