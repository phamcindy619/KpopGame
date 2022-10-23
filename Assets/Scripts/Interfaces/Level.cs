using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    public abstract float GetTimeForLevel();
    public abstract void PlayGame();
    public abstract void EndGame();
    public abstract bool IsSuccessful();
}
