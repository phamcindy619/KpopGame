using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    private string _creditsFilePath;
    [SerializeField] private TextMeshProUGUI _creditsText;

    [SerializeField] private Button _backButton;

    // Start is called before the first frame update
    void Start()
    {
        _creditsFilePath = Application.streamingAssetsPath + "/Texts/Credits.txt";

        DisplayCredits();

        _backButton.onClick.AddListener(EventManager.ButtonClicked);
    }

    // Display all the text from the credits file
    private void DisplayCredits() {
        string[] fileLines = File.ReadAllLines(_creditsFilePath);
        foreach (string line in fileLines) {
            _creditsText.text += line + "\n";
        }
    }

    public void CloseCredits() {
        gameObject.SetActive(false);
    }
}
