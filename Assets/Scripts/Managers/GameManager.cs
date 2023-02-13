using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager instance = null;

    // UI
    private GameObject _missionPanel;
    private GameObject _countdown;
    private GameObject _timer;
    private Level _level;
    private LevelLoader _loader;

    private GameObject _successPanel;
    private GameObject _failPanel;

    private void Awake() {
        // Check if there is another GameManager
        if (instance == null)
            instance = this;
        // Destroy duplicates
        else if (instance != this)
            Destroy(gameObject);

        // Don't destroy GameManager when reloading the scene
        DontDestroyOnLoad(gameObject);
    }

    public void OpenMission() {
        _missionPanel = GameObject.Find("MissionPanel");
        _countdown = GameObject.Find("Countdown");
        _timer = GameObject.Find("Timer");
        _successPanel = GameObject.Find("SuccessPanel");
        _failPanel = GameObject.Find("FailPanel");

        _missionPanel.SetActive(true);
        _countdown.SetActive(false);
        _timer.SetActive(false);
        _successPanel.SetActive(false);
        _failPanel.SetActive(false);
    }

    // Closes the mission panel and starts countdown
    public void CloseMission() {
        _missionPanel.SetActive(false);
        _countdown.SetActive(true);
    }

    // Needs to call the level's start game method
    public void StartLevel() {
        _level = GameObject.Find("Canvas").GetComponent<Level>();
        _loader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();

        _timer.GetComponent<Timer>().SetStartTime(_level.GetTimeForLevel());
        _timer.SetActive(true);
        _level.PlayGame();
    }

    public void EndLevel() {
        _level.EndGame();

        // Determine level success
        bool won = _level.IsSuccessful();

        if (won) {
            LevelSuccess();
        }
        else {
            LevelFailure();
        }
    }

    private void LevelSuccess() {
        EventManager.OnLevelCleared();
        // Display mission success panel
        _successPanel.SetActive(true);
    }

    private void LevelFailure() {
        EventManager.OnLevelFailed();
        // Display mission fail panel
        _failPanel.SetActive(true);
    }

    // Restarts the current level
    public void RestartLevel() {
        StartCoroutine(_loader.LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    // Go to the next level
    public void NextLevel() {
        StartCoroutine(_loader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

}
