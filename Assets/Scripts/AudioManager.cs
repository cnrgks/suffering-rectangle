using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] backgroundMusics;

    public AudioClip pickUpSfx;
    public AudioClip shieldBreakSfx;
    public AudioClip dieSfx;

    [HideInInspector]
    public AudioSource audioSource;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        int randBgMusic = Random.Range(0, backgroundMusics.Length);
        AudioClip bgMusic = backgroundMusics[randBgMusic];

        audioSource.clip = bgMusic;

        audioSource.Play();
    }

    public void PlayPickUpSfx()
    {
        audioSource.PlayOneShot(pickUpSfx);
    }

    public void PlayShieldBreakSfx()
    {
        audioSource.PlayOneShot(shieldBreakSfx);
    }

    public void PlayDieSfx()
    {
        audioSource.PlayOneShot(dieSfx);
    }
}