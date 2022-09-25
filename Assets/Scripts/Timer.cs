using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : GameTime
{
    private const float TOTAL_TIME_IN_SEC = 15f;
    private bool _done;

    // Start is called before the first frame update
    void Start()
    {
        _timeLeft = TOTAL_TIME_IN_SEC;
        _done = false;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (_timeLeft <= 0 && !_done) {
            _done = true;
            GameManager.instance.EndLevel();
        }
    }
}
