using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject _missionPanel;
    private GameObject _countdown;
    private GameObject _timer;
    private GameObject _successPanel;
    private GameObject _failPanel;

    private void OnEnable() {
        EventManager.LevelOpened += OpenMission;
        EventManager.CountdownStarted += CloseMission;
        EventManager.LevelStarted += StartTimer;
        EventManager.LevelCleared += OpenSuccess;
        EventManager.LevelFailed += OpenFail;
    }

    private void OpenMission() {
        _missionPanel = GameObject.Find("MissionPanel");
        _countdown = GameObject.Find("Countdown");
        _timer = GameObject.Find("Timer");
        _successPanel = GameObject.Find("SuccessPanel");
        _failPanel = GameObject.Find("FailPanel");

        _missionPanel.SetActive(true);
        _countdown.SetActive(false);
        _timer.SetActive(false);
        _successPanel.SetActive(false);
        _failPanel.SetActive(false);
    }

    private void CloseMission() {
        _missionPanel.SetActive(false);
        _countdown.SetActive(true);
    }

    private void StartTimer() {
        Level lvl = GameObject.FindObjectOfType<Level>() as Level;
        _timer.GetComponent<Timer>().SetStartTime(lvl.GetTimeForLevel());
        _timer.SetActive(true);
    }

    private void OpenSuccess() {
        _successPanel.SetActive(true);
    }

    private void OpenFail() {
        _failPanel.SetActive(true);
    }
}
