using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Make the GameManager class a singleton
    public static GameManager instance = null;

    private GameObject _missionPanel;
    private GameObject _countdown;
    private GameObject _timer;
    private Level _level;

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
        _missionPanel = GameObject.FindWithTag("Mission");
        _countdown = GameObject.FindWithTag("Countdown");
        _timer = GameObject.FindWithTag("Timer");

        _missionPanel.SetActive(true);
        _countdown.SetActive(false);
        _timer.SetActive(false);
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

    public void LevelSuccess() {
        // Display mission success panel
    }

    public void LevelFailure() {
        // Display mission fail panel
    }

    // Use button click listener
    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel() {
        int currLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currLevel + 1);
    }

}
