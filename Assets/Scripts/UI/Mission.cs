using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    private string _missionsFilePath;

    // UI
    public TextMeshProUGUI missionText;
    public Button startButton;
    public float textSpeed = 0.05f;

    // Sounds
    public AudioClip clickClip;

    // Start is called before the first frame update
    void Start()
    {
        _missionsFilePath = Application.streamingAssetsPath + "/Texts/Missions.txt";

        missionText.gameObject.AddComponent<ReadTextFile>();
        missionText.gameObject.AddComponent<TextWriter>();
        DisplayText();

        startButton.onClick.AddListener(GameManager.instance.CloseMission);
        startButton.onClick.AddListener(() => SoundManager.instance.PlaySingle(clickClip));
    }

    void DisplayText() {
        string text = missionText.gameObject.GetComponent<ReadTextFile>().ReadText(_missionsFilePath);
        missionText.gameObject.GetComponent<TextWriter>().AddWriter(missionText, text, textSpeed);
    }
}
