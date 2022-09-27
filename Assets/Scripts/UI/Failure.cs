using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Failure : ReadTextFile
{
    private string _failFilePath;

    // UI
    public TextMeshProUGUI failText;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        _failFilePath = Application.streamingAssetsPath + "/Texts/Failure.txt";
        
        DisplayText(_failFilePath, failText);

        restartButton.onClick.AddListener(GameManager.instance.RestartLevel);
    }
}
