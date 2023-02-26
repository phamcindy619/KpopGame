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
        _missionsFilePath = Application.streamingAssetsPath + "/Texts/Missions.txt";

        _missionText.gameObject.AddComponent<ReadTextFile>();
        _missionText.gameObject.AddComponent<TextWriter>();
        DisplayText();

        _startButton.onClick.AddListener(EventManager.CountdownStarted);
        _startButton.onClick.AddListener(EventManager.ButtonClicked);
    }

    void DisplayText() {
        string text = _missionText.gameObject.GetComponent<ReadTextFile>().ReadText(_missionsFilePath);
        _missionText.gameObject.GetComponent<TextWriter>().AddWriter(_missionText, text, textSpeed);
    }
}
