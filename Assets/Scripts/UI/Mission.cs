using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    private string _missionsFilePath;

    // UI
    [SerializeField] private TextMeshProUGUI _missionText;
    [SerializeField] private Button _startButton;
    public float textSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        _missionsFilePath = "Texts/Missions";

        _missionText.gameObject.AddComponent<TextWriter>();
        DisplayText();

        _startButton.onClick.AddListener(EventManager.CountdownStarted);
        _startButton.onClick.AddListener(EventManager.ButtonClicked);
    }

    void DisplayText() {
        ReadTextFile reader = new ReadTextFile();
        string text = reader.ReadLine(_missionsFilePath);
        _missionText.gameObject.GetComponent<TextWriter>().AddWriter(_missionText, text, textSpeed);
    }
}
