using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level1 : Level
{
    public GameObject ticketPanel;
    public Button buyButton;
    public TextMeshProUGUI scoreText;

    // Scoring
    private int _score;
    private const int SCORE_NEEDED_TO_WIN = 100;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        buyButton.onClick.AddListener(IncreaseScore);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
    }

    void Awake() {
        GameManager.instance.OpenMission();
        ticketPanel.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    public override void PlayGame() {
        Debug.Log("Level 1 START");
        ticketPanel.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }

    public override void EndGame() {
        Debug.Log("Level 1 ENDED");
        ticketPanel.SetActive(false);
    }

    private void IncreaseScore() {
        _score++;
    }

    private void DisplayScore() {
        scoreText.text = "Clicks: " + _score;
    }

    // Determines whether the level was successful
    public override bool isSuccessful() {
        if (_score >= SCORE_NEEDED_TO_WIN) {
            return true;
        }
        return false;
    }
}
