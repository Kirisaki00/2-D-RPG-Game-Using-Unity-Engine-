using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;   // Speaker
    public AudioClip musicClip;       // Your music file

    void Start()
    {
        if (audioSource != null && musicClip != null)
        {
            audioSource.clip = musicClip;
            audioSource.loop = true;
            audioSource.spatialBlend = 0f; // 2D sound
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or MusicClip missing!");
        }
    }
}