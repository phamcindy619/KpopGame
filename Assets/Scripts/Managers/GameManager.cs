using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Make the GameManager class a singleton
    public static GameManager instance = null;

    // Game Objects in every scene
    private GameObject _missionPanel;
    private GameObject _countdown;
    private GameObject _timer;
    private Level _level;

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
        Debug.Log("Open mission");
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
        Debug.Log("Close mission");
        _missionPanel.SetActive(false);
        _countdown.SetActive(true);
    }

    // Needs to call the level's start game method
    public void StartLevel() {
        _timer.SetActive(true);

        _level = GameObject.Find("Canvas").GetComponent<Level>();
        _level.PlayGame();
    }

    public void EndLevel() {
        _level.EndGame();

        // Determine level success
        bool won = _level.isSuccessful();

        if (won) {
            LevelSuccess();
        }
        else {
            LevelFailure();
        }
    }

    private void LevelSuccess() {
        // Display mission success panel
        _successPanel.SetActive(true);
    }

    private void LevelFailure() {
        // Display mission fail panel
        _failPanel.SetActive(true);
    }

    // Restarts the current level
    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Go to the next level
    public void NextLevel() {
        int currLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currLevel + 1);
    }

}
