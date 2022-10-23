using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    protected float _timeLeft;
    public TextMeshProUGUI timeText;

    // Update is called once per frame
    public void Update()
    {
        //  Timer running
        if (_timeLeft > 0) {
            _timeLeft -= Time.deltaTime;
            DisplayTime();
        }
        // Timer ended
        else {
            _timeLeft = 0;
        }
    }

    // Display the time remaining in seconds
    private void DisplayTime() {
        timeText.text = _timeLeft.ToString("0");
    }
}
