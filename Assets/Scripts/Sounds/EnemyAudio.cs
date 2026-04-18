using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attackSound;

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }
}