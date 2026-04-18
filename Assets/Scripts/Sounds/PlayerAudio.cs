using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip swordSound;
    void Start()
    {
        Debug.Log("Script is running");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Right Click");
                audioSource.PlayOneShot(swordSound);
            }
    }
}