using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : GameTime
{
    private bool _done;

    // Start is called before the first frame update
    void Start()
    {
        _done = false;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (_timeLeft <= 0 && !_done) {
            _done = true;
            EventManager.OnMissionEnd();
        }
    }

    public void SetStartTime(float time) {
        _timeLeft = time;
    }
}
