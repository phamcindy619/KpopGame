using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Make the GameManager class a singleton
    private static GameManager _instance;
    
    public static GameManager Instance {
        get {
            if (_instance == null) {
                Debug.LogError("Game Manager is NULL");
            }

            return _instance;
        }
    }

    // Get the timer
    public GameObject timer;

    private void Awake() {
        _instance = this;
    }

    private void Update() {
        // Timer has run out
        if (int.Parse(timer.GetComponent<TextMeshProUGUI>().text) <= 0) {
            EndLevel();
        }
    }

    // Needs to call the level's start game method
    public void StartLevel() {

    }

    public void EndLevel() {

    }

    public void LevelSuccess() {

    }

    public void LevelFailure() {
        
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel() {
        int currLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currLevel + 1);
    }

}
