using UnityEngine;

public class Quitter : MonoBehaviour
{
#if UNITY_WEBPLAYER
     public static string webplayerQuitURL = "https://itch.io";
#endif
    public static void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
        Application.Quit();
#endif
    }
}