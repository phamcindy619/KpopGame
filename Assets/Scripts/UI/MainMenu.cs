using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject credits;
    public Button creditsButton;
    public Button startButton;

    private LevelLoader _loader;

    void Start() {
        _loader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        credits.SetActive(false);
        creditsButton.onClick.AddListener(EventManager.ButtonClicked);
        startButton.onClick.AddListener(EventManager.ButtonClicked);
        EventManager.OnGameStart();
    }

    public void StartGame() {
        StartCoroutine(_loader.LoadLevel(1));
    }

    public void OpenCredits() {
        credits.SetActive(true);
    }
}
