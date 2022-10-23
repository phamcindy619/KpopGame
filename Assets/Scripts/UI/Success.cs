using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Success : ReadTextFile
{
    private string _successFilePath;

    // UI
    public TextMeshProUGUI successText;
    public Button nextButton;

    // Sounds
    public AudioClip clickClip;

    // Start is called before the first frame update
    void Start()
    {
        _successFilePath = Application.streamingAssetsPath + "/Texts/Success.txt";

        DisplayText(_successFilePath, successText);

        nextButton.onClick.AddListener(GameManager.instance.NextLevel);
        nextButton.onClick.AddListener(() => SoundManager.instance.PlaySingle(clickClip));
    }
}
