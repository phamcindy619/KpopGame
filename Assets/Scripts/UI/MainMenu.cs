using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject credits;

    void Start() {
        credits.SetActive(false);
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void OpenCredits() {
        credits.SetActive(true);
    }
}
