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
        _failFilePath = Application.streamingAssetsPath + "/Texts/Failure.txt";
        
        _failText.gameObject.AddComponent<ReadTextFile>();
        DisplayText();

        _restartButton.onClick.AddListener(GameManager.instance.RestartLevel);
        _restartButton.onClick.AddListener(EventManager.ButtonClicked);
    }

    public void DisplayText() {
        _failText.text = _failText.gameObject.GetComponent<ReadTextFile>().ReadText(_failFilePath);
    }
}
