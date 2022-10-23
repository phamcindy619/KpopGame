using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mission : ReadTextFile
{
    private string _missionsFilePath;

    // UI
    public TextMeshProUGUI missionText;
    public Button startButton;

    // Sounds
    public AudioClip clickClip;

    // Start is called before the first frame update
    void Start()
    {
        _missionsFilePath = Application.streamingAssetsPath + "/Texts/Missions.txt";

        DisplayText(_missionsFilePath, missionText);

        startButton.onClick.AddListener(GameManager.instance.CloseMission);
        startButton.onClick.AddListener(() => SoundManager.instance.PlaySingle(clickClip));
    }
}
