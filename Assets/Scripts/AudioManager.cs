using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    AudioSource audioSource;
    public AudioClip explosionSound;
    public AudioClip themeSound;
    public AudioClip gameOverSound;

    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayExplosion()
    {
        audioSource.loop = false;
        audioSource.clip = explosionSound;
        audioSource.Play();
    }

    public void PlayTheme()
    {
        audioSource.clip = themeSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayGameOver()
    {
        audioSource.loop = false;
        audioSource.clip = gameOverSound;
        audioSource.Play();
    }

    public void stopTheme()
    {
        audioSource.Stop();
    }
    public void stopGameOver()
    {
        audioSource.Stop();
    }
}
