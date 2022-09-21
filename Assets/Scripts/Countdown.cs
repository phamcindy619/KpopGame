using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public const float COUNTDOWN_TIME_IN_SEC = 5f;
    public float timeLeft;

    private TextMeshProUGUI _countdownText;


    // Start is called before the first frame update
    void Start()
    {
        _countdownText = GetComponent<TextMeshProUGUI>();
        timeLeft = COUNTDOWN_TIME_IN_SEC;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown running
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            DisplayTime(timeLeft);
        }
        // Countdown ended
        else {
            timeLeft = 0;
            gameObject.SetActive(false);

            // Start level
        }
    }

    public void StartCountdown() {
        gameObject.SetActive(true);
    }

    // Display the time remaining in seconds
    private void DisplayTime(float timeToDisplay) {
        _countdownText.text = timeLeft.ToString("0");
    }
}
