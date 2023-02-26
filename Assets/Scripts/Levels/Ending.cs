using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnEndingScene();
        _mainMenuButton.onClick.AddListener(EventManager.ButtonClicked);
    }

    public void EndGame() {
        SceneManager.LoadScene(0);
    }
}
