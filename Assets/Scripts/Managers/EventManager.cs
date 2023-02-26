using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    // Events
    public static UnityAction ButtonClicked;
    public static UnityAction LevelOpened;
    public static UnityAction LevelStarted;
    public static UnityAction LevelCleared;
    public static UnityAction LevelFailed;
    public static UnityAction EndingSceneOpened;
    public static UnityAction GameStarted;
    public static UnityAction CountdownStarted;

    public static void OnLevelOpen() {
        LevelOpened?.Invoke();
    }

    public static void OnLevelStart() {
        LevelStarted?.Invoke();
    }

    public static void OnLevelClear() {
        LevelCleared?.Invoke();
    }

    public static void OnLevelFail() {
        LevelFailed?.Invoke();
    }

    public static void OnEndingScene() {
        EndingSceneOpened?.Invoke();
    }

    public static void OnGameStart() {
        GameStarted?.Invoke();
    }

    public static void OnCountdownStart() {
        CountdownStarted?.Invoke();
    }
}
