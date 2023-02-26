using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level1 : MonoBehaviour, ILevel
{
    // UI
    public GameObject ticketPanel;
    public Button buyButton;
    public TextMeshProUGUI scoreText;

    // Scoring
    private int _score;
    private const int SCORE_NEEDED_TO_WIN = 60;
    private const float TIME_FOR_LEVEL = 15f;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        buyButton.onClick.AddListener(IncreaseScore);
    }

    void Awake() {
        EventManager.OnLevelStart();
        
        ticketPanel.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    public void PlayGame() {
        ticketPanel.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }

    public void EndGame() {
        ticketPanel.SetActive(false);
    }

    private void IncreaseScore() {
        _score++;
        DisplayScore();
    }

    private void DisplayScore() {
        scoreText.text = "Clicks: " + _score;
    }

    // Determines whether the level was successful
    public bool IsSuccessful() {
        if (_score >= SCORE_NEEDED_TO_WIN) {
            return true;
        }
        return false;
    }

    public float GetTimeForLevel()
    {
        return TIME_FOR_LEVEL;
    }
}
