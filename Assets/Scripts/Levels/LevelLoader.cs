using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator _transition;
    public float transitionTime = 2f;

    public IEnumerator LoadLevel(int levelIndex) {
        // Play animation
        _transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load new scene
        SceneManager.LoadScene(levelIndex);
    }
}
