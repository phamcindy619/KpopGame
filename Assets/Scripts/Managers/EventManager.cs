using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityAction ButtonClicked;
    public static UnityAction LevelCleared;
    public static UnityAction LevelFailed;
    public static UnityAction EndingSceneOpened;
    public static UnityAction GameStarted;

    public static void OnLevelCleared() {
        LevelCleared?.Invoke();
    }

    public static void OnLevelFailed() {
        LevelFailed?.Invoke();
    }

    public static void OnEndingScene() {
        EndingSceneOpened?.Invoke();
    }

    public static void OnGameStarted() {
        GameStarted?.Invoke();
    }
}
