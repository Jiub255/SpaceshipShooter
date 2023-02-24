using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource effectsSource;
    public AudioSource musicSource;

    private void Start()
    {
        musicSource.ignoreListenerPause = true;
    }

    public void PlaySoundEffect(AudioClip effectClip)
    {
        if (effectsSource != null)
        {
            // Use PlayOneShot so multiple clips can be played at once without cutting off the previous played one. 
            effectsSource.PlayOneShot(effectClip);
        }
    }

    public void PlayMusic(AudioClip musicClip)
    {
        if (musicSource != null)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }
    }
}