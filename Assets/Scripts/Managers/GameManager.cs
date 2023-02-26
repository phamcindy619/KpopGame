using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager instance = null;

    private ILevel _level;
    private LevelLoader _loader;

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

    // Needs to call the level's start game method
    public void StartLevel() {
        EventManager.OnLevelStart();
        _level = FindObjectsOfType<MonoBehaviour>().OfType<ILevel>().FirstOrDefault();
        _loader = FindObjectOfType<LevelLoader>() as LevelLoader;
        _level.PlayGame();
    }

    public void EndLevel() {
        _level.EndGame();

        // Determine level success
        bool won = _level.IsSuccessful();

        if (won) {
            EventManager.OnLevelClear();
        }
        else {
            EventManager.OnLevelFail();
        }
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
