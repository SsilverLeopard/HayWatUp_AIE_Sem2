using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource; // the main background music
    [SerializeField] private AudioSource newAudioSource; // the new sound to play on collision

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // make sure to tag your player as "Player"
        {
            // Pause current music
            if (musicSource.isPlaying)
                musicSource.Pause();

            // Play new sound
            if (!newAudioSource.isPlaying)
                newAudioSource.Play();
        }
    }
}
