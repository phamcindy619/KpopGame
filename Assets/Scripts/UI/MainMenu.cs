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

    // Sounds
    public AudioClip backgroundSong;
    public AudioClip clickClip;

    void Start() {
        credits.SetActive(false);
        SoundManager.instance.PlayMusic(backgroundSong);
        creditsButton.onClick.AddListener(() => SoundManager.instance.PlaySingle(clickClip));
        startButton.onClick.AddListener(() => SoundManager.instance.PlaySingle(clickClip));
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void OpenCredits() {
        credits.SetActive(true);
    }
}
