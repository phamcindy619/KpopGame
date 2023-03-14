using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _credits;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;

    private LevelLoader _loader;

    void Start() {
        _loader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        _credits.SetActive(false);
        _creditsButton.onClick.AddListener(EventManager.ButtonClicked);
        _startButton.onClick.AddListener(EventManager.ButtonClicked);
        _quitButton.onClick.AddListener(EventManager.ButtonClicked);
        EventManager.OnGameStart();
    }

    public void StartGame() {
        StartCoroutine(_loader.LoadLevel(1));
    }

    public void OpenCredits() {
        _credits.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
