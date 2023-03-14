using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        ReadTextFile reader = new ReadTextFile();
        _creditsText.text = reader.ReadAll(_creditsFilePath);
    }

    public void CloseCredits() {
        gameObject.SetActive(false);
    }
}
