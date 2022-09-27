using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : GameTime
{
    private const float COUNTDOWN_TIME_IN_SEC = 5f;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        _timeLeft = COUNTDOWN_TIME_IN_SEC;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        if (_timeLeft <= 0) {
            gameObject.SetActive(false);

            // Start level
            GameManager.instance.StartLevel();
        }
    }
}
