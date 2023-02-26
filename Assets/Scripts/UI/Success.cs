using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Success : MonoBehaviour
{
    private string _successFilePath;

    // UI
    [SerializeField] private TextMeshProUGUI _successText;
    [SerializeField] private Button _nextButton;

    // Start is called before the first frame update
    void Start()
    {
        _successFilePath = Application.streamingAssetsPath + "/Texts/Success.txt";

        _successText.gameObject.AddComponent<ReadTextFile>();
        DisplayText();

        _nextButton.onClick.AddListener(GameManager.instance.NextLevel);
        _nextButton.onClick.AddListener(EventManager.ButtonClicked);
    }

    public void DisplayText() {
        _successText.text = _successText.gameObject.GetComponent<ReadTextFile>().ReadText(_successFilePath);
    }
}
