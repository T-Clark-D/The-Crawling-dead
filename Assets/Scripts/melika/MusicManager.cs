using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] backgroundMusicList;
    private AudioSource audioSource;
    private int currentTrackIndex = 0;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerPrefsManager.SetMasterVolume(0.1f);
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        PlayNextTrack();
    }


    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    void PlayNextTrack()
    {
        audioSource.clip = backgroundMusicList[currentTrackIndex];
        audioSource.Play();
        currentTrackIndex = (currentTrackIndex + 1) % backgroundMusicList.Length;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
