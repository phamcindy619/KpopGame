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
    private const int SCORE_NEEDED_TO_WIN = 75;
    private const float TIME_FOR_LEVEL = 15f;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        buyButton.onClick.AddListener(IncreaseScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        GameManager.instance.OpenMission();
        ticketPanel.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    public override void PlayGame() {
        ticketPanel.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }

    public override void EndGame() {
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
    public override bool IsSuccessful() {
        // #if UNITY_EDITOR
        //     return true;
        // #endif

        if (_score >= SCORE_NEEDED_TO_WIN) {
            return true;
        }
        return false;
    }

    public override float GetTimeForLevel()
    {
        return TIME_FOR_LEVEL;
    }
}
