using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Credits : MonoBehaviour
{
    [HideInInspector]
    public string creditsFilePath;
    public TextMeshProUGUI creditsText;

    // Start is called before the first frame update
    void Start()
    {
        creditsFilePath = Application.streamingAssetsPath + "/Texts/Credits.txt";

        DisplayCredits();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Display all the text from the credits file
    private void DisplayCredits() {
        string[] fileLines = File.ReadAllLines(creditsFilePath);
        foreach (string line in fileLines) {
            creditsText.text += line + "\n";
        }
    }

    public void CloseCredits() {
        gameObject.SetActive(false);
    }
}
