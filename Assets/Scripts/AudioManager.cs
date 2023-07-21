using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;


    public AudioClip background;
    public AudioClip jump;
    public AudioClip kill;
    public AudioClip die;
    public AudioClip bomb;


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void Mute()
    {
        musicSource.clip = background;
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
