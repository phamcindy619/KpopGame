using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevel
{
    float GetTimeForLevel();
    void PlayGame();
    void EndGame();
    bool IsSuccessful();
}
