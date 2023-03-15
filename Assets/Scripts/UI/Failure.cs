using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Failure : MonoBehaviour
{
    private string _failFilePath;

    // UI
    [SerializeField] private TextMeshProUGUI _failText;
    [SerializeField] private Button _restartButton;

    // Start is called before the first frame update
    void Start()
    {
        _failFilePath = "Texts/Failure";
        DisplayText();

        _restartButton.onClick.AddListener(GameManager.instance.RestartLevel);
        _restartButton.onClick.AddListener(EventManager.ButtonClicked);
    }

    public void DisplayText() {
        ReadTextFile reader = new ReadTextFile();
        _failText.text = reader.ReadLine(_failFilePath);
    }
}
