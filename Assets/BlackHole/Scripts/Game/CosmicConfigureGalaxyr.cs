using UnityEngine;

namespace rIAEugth.vseioAW.Game
{
    public class CosmicConfigureGalaxyr:MonoBehaviour
    {
        public void ConfigureGalaxy()
        {
            UniWebView.SetAllowInlinePlay(true);
            
            var audioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (var audioSource in audioSources)
            {
                audioSource.Stop();
            }

            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}