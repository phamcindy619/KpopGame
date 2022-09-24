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

    // Start is called before the first frame update
    void Start()
    {
        _missionsFilePath = Application.streamingAssetsPath + "/Missions.txt";

        DisplayText(_missionsFilePath, missionText);

        startButton.onClick.AddListener(GameManager.instance.CloseMission);
    }
}
