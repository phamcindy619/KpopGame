using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public AudioClip endingSong;
    public AudioClip cheeringClip;
    public AudioClip clickClip;

    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayMusic(endingSong);
        SoundManager.instance.PlaySingle(cheeringClip);
        mainMenuButton.onClick.AddListener(() => SoundManager.instance.PlaySingle(clickClip));
    }

    public void EndGame() {
        SceneManager.LoadScene(0);
    }
}
