using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event (AudioClip)",
    menuName = "Scriptable Objects/Game Events/Game Event (AudioClip)")]
public class GEAudioClip : ScriptableObject
{
    private List<GELAudioClip> listeners =
        new List<GELAudioClip>();

    public void Raise(AudioClip AudioClip)
    {
        // Iterate backwards in case the event causes them to 
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(AudioClip);
        }
    }

    public void RegisterListener(GELAudioClip listener)
    {
        listeners.Add(listener);
    }
    public void UnregisterListener(GELAudioClip listener)
    {
        listeners.Remove(listener);
    }
}