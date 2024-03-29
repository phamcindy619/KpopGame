using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    // Singleton instance
    public static SoundManager instance = null;

    // Audio sources
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;

    // Clips
    [Header("Audio Clips")]
    [SerializeField] private AudioClip _bgm;
    [SerializeField] private AudioClip _endingSong;
    [SerializeField] private AudioClip _clickSFX;
    [SerializeField] private AudioClip _successSFX;
    [SerializeField] private AudioClip _failureSFX;
    [SerializeField] private AudioClip _cheerSFX;
    [SerializeField] private AudioClip _countdownSFX;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable() {
        EventManager.GameStarted += PlayBGM;
        EventManager.ButtonClicked += ClickSFX;
        EventManager.CountdownStarted += CountdownSFX;
        EventManager.LevelCleared += SuccessSFX;
        EventManager.LevelFailed += FailureSFX;
        EventManager.EndingSceneOpened += CheerSFX;
        EventManager.EndingSceneOpened += PlayEndingMusic;
    }

    private void OnDisable() {
        EventManager.GameStarted -= PlayBGM;
        EventManager.ButtonClicked -= ClickSFX;
        EventManager.CountdownStarted -= CountdownSFX;
        EventManager.LevelCleared -= SuccessSFX;
        EventManager.LevelFailed -= FailureSFX;
        EventManager.EndingSceneOpened -= CheerSFX;
        EventManager.EndingSceneOpened -= PlayEndingMusic;
    }

    private void PlayMusic(AudioClip clip) {
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    private void PlayBGM() {
        PlayMusic(_bgm);
    }

    private void PlayEndingMusic() {
        PlayMusic(_endingSong);
    }

    private void ClickSFX() {
        _sfxSource.PlayOneShot(_clickSFX);
    }

    private void SuccessSFX() {
        _sfxSource.PlayOneShot(_successSFX);
    }

    private void FailureSFX() {
        _sfxSource.PlayOneShot(_failureSFX);
    }

    private void CheerSFX() {
        _sfxSource.PlayOneShot(_cheerSFX);
    }

    private void CountdownSFX() {
        _sfxSource.PlayOneShot(_countdownSFX);
    }
}
