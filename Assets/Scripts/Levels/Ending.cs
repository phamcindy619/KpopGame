using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;

    float timeTilButtonFadesIn = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnEndingScene();
        _mainMenuButton.onClick.AddListener(EventManager.ButtonClicked);
        StartFade(_mainMenuButton);
    }

    public void EndGame() {
        SceneManager.LoadScene(0);
    }

    private void StartFade(Button button) {
        // Set button as invisible
        CanvasGroup group = button.gameObject.GetComponent<CanvasGroup>();
        group.alpha = 0;
        StartCoroutine(FadeIn(button));
    }

    private IEnumerator FadeIn(Button button) {
        yield return new WaitForSeconds(timeTilButtonFadesIn);
        CanvasGroup group = button.gameObject.GetComponent<CanvasGroup>();
        while (group.alpha < 1) {
            group.alpha += Time.deltaTime;
            yield return null;
        }
    }
}
