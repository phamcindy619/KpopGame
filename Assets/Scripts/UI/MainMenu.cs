using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject credits;
    public Button creditsButton;
    public Button startButton;

    private LevelLoader _loader;

    // Sounds
    public AudioClip backgroundSong;
    public AudioClip clickClip;

    void Start() {
        _loader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        credits.SetActive(false);
        SoundManager.instance.PlayMusic(backgroundSong);
        creditsButton.onClick.AddListener(() => SoundManager.instance.PlaySingle(clickClip));
        startButton.onClick.AddListener(() => SoundManager.instance.PlaySingle(clickClip));
    }

    public void StartGame() {
        StartCoroutine(_loader.LoadLevel(1));
    }

    public void OpenCredits() {
        credits.SetActive(true);
    }
}
