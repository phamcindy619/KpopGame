using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Failure : MonoBehaviour
{
    private string _failFilePath;

    // UI
    public TextMeshProUGUI failText;
    public Button restartButton;
    
    // Sounds
    public AudioClip clickClip;

    // Start is called before the first frame update
    void Start()
    {
        _failFilePath = Application.streamingAssetsPath + "/Texts/Failure.txt";
        
        failText.gameObject.AddComponent<ReadTextFile>();
        DisplayText();

        restartButton.onClick.AddListener(GameManager.instance.RestartLevel);
        restartButton.onClick.AddListener(() => SoundManager.instance.PlaySingle(clickClip));
    }

    public void DisplayText() {
        failText.text = failText.gameObject.GetComponent<ReadTextFile>().ReadText(_failFilePath);
    }
}
