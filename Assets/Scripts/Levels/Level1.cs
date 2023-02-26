using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level1 : MonoBehaviour, ILevel
{
    // UI
    [Header("UI")]
    [SerializeField] private GameObject _ticketPanel;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI _scoreText;

    // Scoring
    private int _score;
    private const int SCORE_NEEDED_TO_WIN = 60;
    private const float TIME_FOR_LEVEL = 15f;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _buyButton.onClick.AddListener(IncreaseScore);
    }

    void Awake() {
        EventManager.OnLevelStart();
        
        _ticketPanel.SetActive(false);
        _scoreText.gameObject.SetActive(false);
    }

    public void PlayGame() {
        _ticketPanel.SetActive(true);
        _scoreText.gameObject.SetActive(true);
    }

    public void EndGame() {
        _ticketPanel.SetActive(false);
    }

    private void IncreaseScore() {
        _score++;
        DisplayScore();
    }

    private void DisplayScore() {
        _scoreText.text = "Clicks: " + _score;
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
