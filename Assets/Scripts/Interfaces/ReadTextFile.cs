using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

/*
    Text files should follow the format with empty lines in between:
    Line 1

    Line 2

    Line 3
*/

public class ReadTextFile : MonoBehaviour
{
    private StreamReader _sr;

    public void DisplayText(string filePath, TextMeshProUGUI textBox) {
        _sr = new StreamReader(filePath);

        int levelNum = int.Parse(SceneManager.GetActiveScene().name.Substring(5));

        for (int i = 0; i < levelNum; i++) {
            textBox.text = _sr.ReadLine();
            _sr.ReadLine();
        }
    }
}
